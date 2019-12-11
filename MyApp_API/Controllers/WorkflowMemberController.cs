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
    public class WorkflowMemberController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkflowMemberService _service;

        public WorkflowMemberController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.GetRequiredService<IWorkflowMemberService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }

        #region create
        /// <summarycreate
        /// create
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<WorkflowMemberViewPage>>> addMember([FromBody]WorkflowMemberCreateViewPage request)
        {

            var result = await _service.addMember(request);

            return result;
        }

        #endregion

    }
}
