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

        #region GetMyUser
        /// <summary>
        /// GetMyUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<UserViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<UserViewPage>>> GetMyUser([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _userService.GetAllUser(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="request"></param>
        /// <returns>bool</returns>
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

        #region Update
        /// <summary>
        /// update
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        /// 
        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody]UserUpdateViewPage request)
        {
            var entity = _userService.Update(id, request);
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
    }
}
