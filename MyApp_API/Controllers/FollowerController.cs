using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFollowerService _followerService;
        public FollowerController(IServiceProvider serviceProvider)
        {
            _followerService = serviceProvider.GetRequiredService<IFollowerService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }

        #region Get All Follower
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<FollowerViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<FollowerViewPage>>> getAllFollower()
        {


            var result = _followerService.getAllFollowerByAuthor();

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region follow
        /// <summary>
        /// follow
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost("follow")]
        public ActionResult<BaseViewModel<FollowerViewPage>> follow([FromBody]FollowerCreateViewPage request)
        {

            var result = _followerService.follow(request);
            this.HttpContext.Response.StatusCode = (int)result.StatusCode;
            return result;
        }

        #endregion

        #region unfollow
        /// <summary>
        /// unfollow
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost("unfollow")]
        public ActionResult<BaseViewModel<FollowerViewPage>> unfollow([FromBody]FollowerCreateViewPage request)
        {

            var result = _followerService.unfollow(request);
            this.HttpContext.Response.StatusCode = (int)result.StatusCode;
            return result;
        }

        #endregion
    }
}