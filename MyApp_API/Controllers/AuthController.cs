﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyApp.Core.Configs;
using MyApp.Core.Data.Entity;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Field

        private readonly IRegisterService _userService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        #endregion

        #region Ctor

        public AuthController(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _accessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            _userService = serviceProvider.GetRequiredService<IRegisterService>();
        }

        #endregion

        #region Login

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>linhnnm</author>
        [HttpPost("Login")]
        public ActionResult<BaseViewModel<TokenViewModel>> Login([FromBody]LoginViewModel request)
        {
            var entity = _userService.Login(request);
            return Ok(new BaseViewModel<TokenViewModel>
            {
                Data = GenerateToken(entity.Data),
            });

        }

        #endregion

        #region Register

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost("Register")]
        public ActionResult Register([FromBody]RegisterViewModel request)
        {
            var entity = _userService.Register(request);

            return Ok(new BaseViewModel<TokenViewModel>(GenerateToken(entity.Data)));

        }

        #endregion

        #region ===== Generate Token ======

        private TokenViewModel GenerateToken(Register user)
        {

            var Key = BuildRsaSigningKey();

            //signing credentials
            var signingCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha512Signature);

            //add Claims
            var claims = new List<Claim>();

            claims.Add(new Claim(MyApp.Core.Constaint.Constants.CLAIM_USERNAME, user.Username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Username.ToString()));
            //create token
            var token = new JwtSecurityToken(
                    issuer: AppSettings.Configs.GetValue<string>("JwtSettings:Issuer"),
                    audience: user.Fullname,
                    expires: DateTime.Now.AddYears(1),
                    signingCredentials: signingCredentials,
                    claims: claims
                );
            //return token
            return new TokenViewModel
            {
                Roles = user.Role,
                Access_token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires_in = DateTime.Now.AddYears(1),

                //(int)TimeSpan.FromDays(1).TotalSeconds
            };
        }

        #endregion

        #region ===== Build RSA Sercurity ======

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

        #endregion
    }
}