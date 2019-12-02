using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITaskService _service;

        public TaskController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.GetRequiredService<ITaskService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }

        #region Get All Task
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<TaskViewPage>>> getAllTask([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _service.getAllTask(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Get My Task
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet("{id}")]
        public ActionResult<BaseViewModel<TaskViewPage>> getWorkflow(string id)
        {

            var result = _service.getTaskById(id);

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
        public ActionResult<BaseViewModel<IEnumerable<TaskViewPage>>> create([FromBody]TaskCreateViewPage request)
        {

            var result = _service.create(request);

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
        [HttpPost("instance")]
        public ActionResult<BaseViewModel<TaskViewPage>> createInstance([FromBody]TaskCreateInstanceViewPage request)
        {

            var result = _service.createIntance(request);

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
        public ActionResult<BaseViewModel<TaskViewPage>> update([FromBody]TaskUpdateViewPage request)
        {

            var result = _service.update(request);

            return result;
        }

        #endregion

        #region change status
        /// <summary>
        /// update
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPatch("{id}")]
        public ActionResult<BaseViewModel<TaskViewPage>> changeStatus(string id, [FromBody]TaskChangeStatusViewPage request)
        {

            var result = _service.changeStatus(id, request);

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