using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Data.Entity;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INotificationService _service;

        public NotificationsController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.GetRequiredService<INotificationService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }

        #region Get All Notification
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<NotificationViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<NotificationViewPage>>> getAllNotification([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _service.getAllNotification(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Get Notification By Id
        /// <summary>
        /// WorkflowsByHistory
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<CommentViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet("{id}")]
        public ActionResult<BaseViewModel<NotificationViewPage>> getNotificationById(string id)
        {

            var result = _service.getNotificationById(id);

            return result;
        }

        #endregion

        #region create
        /// <summarycreate
        /// create
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost]
        public ActionResult<BaseViewModel<NotificationViewPage>> create([FromBody]NotificationCreateViewPage request)
        {

            var result = _service.create(request);

            return result;
        }

        #endregion

        #region update
        /// <summary>
        /// update
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPut]
        public ActionResult<BaseViewModel<NotificationViewPage>> update([FromBody]NotificationUpdateViewPage request)
        {

            var result = _service.update(request);

            return result;
        }

        #endregion

        #region read
        /// <summary>
        /// read
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPatch("{id}")]
        public ActionResult<BaseViewModel<NotificationViewPage>> read(string id)
        {

            var result = _service.readed(id);

            return result;
        }

        #endregion

        #region delete
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpDelete("{id}")]
        public ActionResult<BaseViewModel<bool>> delete(string id)
        {

            var result = _service.delete(id);

            return result;
        }

        #endregion
    }
}
