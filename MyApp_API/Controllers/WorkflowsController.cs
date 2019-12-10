﻿using System;
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
    public class WorkflowsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkflowService _projectService;

        public WorkflowsController(IServiceProvider serviceProvider)
        {
            _projectService = serviceProvider.GetRequiredService<IWorkflowService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }

        #region Get All Workflow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<WorkflowViewPage>>> getAllWorkflow([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _projectService.getAllWorkflow(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Get All Workflow By History
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet("WorkflowsByHistory")]
        public ActionResult<BaseViewModel<PagingResult<WorkflowViewPage>>> getAllWorkflowByHistory([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _projectService.getAllWorkflowByHistory(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Get Workflow Of User By Admin
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet("WorkflowOfUserByAdmin")]
        public ActionResult<BaseViewModel<PagingResult<WorkflowViewPage>>> getWorkflowOfUserByAdmin([FromQuery]WorkflowAdminRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _projectService.getWorkflowUserByAdmin(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Get All Workflow By Admin
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet("WorkflowsByAdmin")]
        public ActionResult<BaseViewModel<PagingResult<WorkflowViewPage>>> getAllWorkflowByAdmin([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _projectService.getAllWorkflowByAdmin(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Get All Workflow By Workflow Id
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet("WorkflowsByWorkflowId")]
        public ActionResult<BaseViewModel<PagingResult<WorkflowViewPage>>> getAllWorkflowByWorkflowId([FromQuery]TaskPagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _projectService.getAllWorkflowByWorkflowId(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Get All Workflow By Status
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet("WorkflowsByStatus")]
        public ActionResult<BaseViewModel<PagingResult<WorkflowViewPage>>> getAllWorkflowByStatus([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _projectService.getAllWorkflowByStatus(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Get All Workflow By Creator
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet("WorkflowsByCreator")]
        public ActionResult<BaseViewModel<PagingResult<WorkflowViewPage>>> getAllWorkflowByCreator([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _projectService.getAllWorkflowByCreator(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Get My Project
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpGet("{id}")]
        public ActionResult<BaseViewModel<WorkflowViewPage>> getWorkflow(string id)
        {

            var result = _projectService.getWorkflowById(id);

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
        public ActionResult<BaseViewModel<WorkflowViewPage>> create([FromBody]WorkflowCreateViewPage request)
        {

            var result = _projectService.create(request);

            return result;
        }

        #endregion

        #region change Status
        /// <summarycreate
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPatch("{id}")]
        public ActionResult<BaseViewModel<WorkflowViewPage>> changeStatus(string id, [FromBody]WorkflowChangeStatusViewPage request)
        {

            var result = _projectService.changeStatus(id, request);

            return result;
        }

        #endregion

        #region create Instance
        /// <summarycreate
        /// create Instance
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost("Instance")]
        public ActionResult<BaseViewModel<WorkflowViewPage>> createInstance([FromBody] WorkflowCreateInstanceViewPage request)
        {

            var result = _projectService.createInstance(request);

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
        public ActionResult<BaseViewModel<WorkflowViewPage>> update([FromBody]WorkflowUpdateViewPage request)
        {

            var result = _projectService.update(request);

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

            var result = _projectService.delete(id);

            return result;
        }

        #endregion
    }
}
