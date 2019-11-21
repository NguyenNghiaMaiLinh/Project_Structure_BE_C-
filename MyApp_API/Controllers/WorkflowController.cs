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
    public class ProjectController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkflowService _projectService;

        public ProjectController(IServiceProvider serviceProvider)
        {
            _projectService = serviceProvider.GetRequiredService<IWorkflowService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }

        #region GetMyProject
        /// <summary>
        /// GetMyProject
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<ProjectViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<ProjectViewPage>>> GetMyProject([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _projectService.GetAllProject(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region create
        /// <summarycreate
        /// GetMyProject
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost("create")]
        public ActionResult<BaseViewModel<ProjectViewPage>> create([FromBody]ProjectCreateViewPage request)
        {

            var result = _projectService.create(request);

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
        [HttpPut("{id}")]
        public ActionResult<BaseViewModel<ProjectViewPage>> update(string id, [FromBody]ProjectUpdateViewPage request)
        {

            var result = _projectService.update(id,request);

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
        [HttpDelete("{id}")]
        public ActionResult<BaseViewModel<bool>> delete( string id)
        {

            var result = _projectService.delete( id);

            return result;
        }

        #endregion
    }
}
