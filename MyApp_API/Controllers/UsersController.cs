using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Net;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        

        public UsersController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<UserViewPage>>> GetMyUser([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _userService.GetAllUser(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #region Register

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost("RegisterAdmin")]
        public ActionResult RegisterAdmin([FromBody]RegisterViewModel request)
        {
            var entity = _userService.RegisterAdmin(request);
            if (entity.Data != null)
            {
                return Ok(entity);
            }
            else
            {

                return BadRequest(new BaseViewModel<UserViewPage>
                {
                    StatusCode = entity.StatusCode,
                    Description = entity.Description,
                    Code = entity.Code,
                });
            }
        }

        #endregion

        #region Register

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost("RegisterStaff")]
        public ActionResult RegisterStaff([FromBody]RegisterViewModel request)
        {
            var entity = _userService.RegisterStaff(request);
            if (entity.Data != null)
            {
                return Ok(entity);
            }
            else
            {

                return BadRequest(new BaseViewModel<UserViewPage>
                {
                    StatusCode = entity.StatusCode,
                    Description = entity.Description,
                    Code = entity.Code,
                });
            }
        }

        #endregion

        #region Register

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost("Delete")]
        public ActionResult Delete([FromBody]UserDeleteViewPage request)
        {
            var entity = _userService.DeleteAccount(request);
            if (entity.Data != false)
            {
                return Ok(entity);
            }
            else
            {

                return BadRequest(new BaseViewModel<bool>
                {
                    StatusCode = entity.StatusCode,
                    Description = entity.Description,
                    Code = entity.Code,
                });
            }
        }

        #endregion
    }
}
