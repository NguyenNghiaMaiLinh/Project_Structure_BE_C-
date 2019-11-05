﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyApp.Core.Configs;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Field

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        #endregion

        #region Ctor

        public AuthController(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _accessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            _userService = serviceProvider.GetRequiredService<IUserService>();
        }

        #endregion

        #region Login

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>thiennb</author>
        [HttpPost("Login")]
        public ActionResult<BaseViewModel<TokenViewModel>> Login([FromBody]LoginViewModel request)
        {
            var entity = _userService.Login(request);
            if (entity.Data == null)
            {
                return BadRequest(new BaseViewModel<TokenViewModel>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Description = ErrMessageConstants.NOTFOUND,
                    Code = ErrMessageConstants.NOTFOUND
                });

            }

            return Ok(new BaseViewModel<TokenViewModel>
            {
                Data = GenerateToken(entity.Data).Result,
            });
        }

        #endregion

        //#region GetToken

        ///// <summary>
        ///// Login
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        ///// <author>thiennb</author>   
        //[Authorize]
        //[HttpGet("GetToken")]
        //public async Task<ActionResult<BaseViewModel<TokenViewModel>>> GetToken()
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return BadRequest(new BaseViewModel<TokenViewModel>
        //        {
        //            Code = ErrMessageConstants.INVALID_USERNAME,
        //            Description = ErrMessageConstants.INVALID_USERNAME,
        //            StatusCode = HttpStatusCode.BadRequest
        //        });
        //    }
        //    // await _userManager.UpdateAsync(user);
        //    return Ok(new BaseViewModel<TokenViewModel>
        //    {
        //        Data = GenerateToken(user).Result,
        //    });
        //}

        //#endregion

        #region Register

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>thiennb</author>
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody]RegisterViewModel request)
        {
            var entity = _userService.Register(request);
            if (entity != null)
            {
                return Ok(new BaseViewModel<TokenViewModel>(GenerateToken(entity.Data).Result));
            }
            else
            {

                return BadRequest(new BaseViewModel<TokenViewModel>
                {
                    StatusCode = HttpStatusCode.PreconditionFailed,
                    Description = ErrMessageConstants.INVALID_USERNAME,
                    Code = ErrMessageConstants.INVALID_USERNAME,
                });
            }
        }

        #endregion

        private async Task<TokenViewModel> GenerateToken(User user)
        {

            var Key = BuildRsaSigningKey();

            //signing credentials
            var signingCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha512Signature);

            //add Claims
            var claims = new List<Claim>();

            claims.Add(new Claim(MyApp.Core.Constaint.Constants.CLAIM_USERNAME, user.Username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            //create token
            var token = new JwtSecurityToken(
                    issuer: AppSettings.Configs.GetValue<string>("JwtSettings:Issuer"),
                    audience: user.FullName,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signingCredentials,
                    claims: claims
                );
            //return token
            return new TokenViewModel
            {
                Roles = null,
                FullName = user.FullName,
                AvatarPath = user.AvatarPath,
                Access_token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires_in = DateTime.Now.AddMinutes(30),

                //(int)TimeSpan.FromDays(1).TotalSeconds
            };
        }

        private RsaSecurityKey BuildRsaSigningKey()
        {
            var parameters = new RSAParameters()
            {
                Modulus = Base64UrlEncoder.DecodeBytes(AppSettings.Configs.GetValue<string>("JwtSettings:RsaModulus")),
                Exponent = Base64UrlEncoder.DecodeBytes(AppSettings.Configs.GetValue<string>("JwtSettings:RsaExponent")),
                P = Base64UrlEncoder.DecodeBytes(AppSettings.Configs.GetValue<string>("JwtSettings:P")),
                Q = Base64UrlEncoder.DecodeBytes(AppSettings.Configs.GetValue<string>("JwtSettings:Q")),
                DP = Base64UrlEncoder.DecodeBytes(AppSettings.Configs.GetValue<string>("JwtSettings:DP")),
                DQ = Base64UrlEncoder.DecodeBytes(AppSettings.Configs.GetValue<string>("JwtSettings:DQ")),
                InverseQ = Base64UrlEncoder.DecodeBytes(AppSettings.Configs.GetValue<string>("JwtSettings:InverseQ")),
                D = Base64UrlEncoder.DecodeBytes(AppSettings.Configs.GetValue<string>("JwtSettings:D")),
            };
            var rsaProvider = new RSACryptoServiceProvider(2048);
            rsaProvider.ImportParameters(parameters);
            var key = new RsaSecurityKey(rsaProvider);
            return key;
        }
        //private async Task CreateRole()
        //{
        //    var roleNames = AppSettings.Configs.GetSection("Role").Get<List<string>>();
        //    IdentityResult roleResult;

        //    foreach (var roleName in roleNames)
        //    {
        //        var roleExist = await _roleManager.RoleExistsAsync(roleName);
        //        if (!roleExist)
        //        {
        //            //create the roles and seed them to the database:
        //            MyRole role = new MyRole() { Name = roleName };
        //            role.SetDefaultInsertValue(GetCurrentUser());
        //            roleResult = await _roleManager.CreateAsync(role);
        //        }
        //    }
        //}
        private string GetCurrentUser()
        {
            //try
            //{
            return _accessor.HttpContext.User?.FindFirst("username")?.Value ?? "SYSTEM";
            //}
            //catch
            //{
            //    return "SYSTEM";
            //}
        }
        //private string GetCurrentUserId()
        //{
        //    //try
        //    //{
        //    return _accessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    //}
        //    //catch
        //    //{
        //    //    return "SYSTEM";
        //    //}
        //}
    }
}