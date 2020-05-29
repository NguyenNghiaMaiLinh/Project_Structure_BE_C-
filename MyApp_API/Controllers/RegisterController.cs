using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Service;
using MyApp.Core.ViewModel.ViewPage;
using System;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegisterController : ControllerBase
    {
        #region Field

        private readonly IRegisterService _userService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        #endregion

        #region Ctor

        public RegisterController(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _accessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            _userService = serviceProvider.GetRequiredService<IRegisterService>();
        }

        #endregion

        #region Get Information

        /// <summary>
        /// Get Information
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet("GetInformation")]
        public ActionResult GetInformation()
        {
            var entity = _userService.GetInformation();
            return Ok(entity);
        }

        #endregion
    }
}