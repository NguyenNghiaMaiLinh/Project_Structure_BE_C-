using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Threading.Tasks;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;

        public CommentsController(IServiceProvider serviceProvider)
        {
            _commentService = serviceProvider.GetRequiredService<ICommentService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }

        #region Get All Comment
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<CommentViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<CommentViewPage>>> getAllComment([FromQuery]CommentPagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _commentService.getAllComment(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        #endregion

        #region Get Comment By Id
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<ProjectViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet("{id}")]
        public ActionResult<BaseViewModel<CommentViewPage>> getCommentById(string id)
        {

            var result = _commentService.getCommentById(id);

            return result;
        }

        #endregion

        #region Get Member IdS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<ProjectViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet("getMemberId")]
        public ActionResult<BaseViewModel<string>> getMemberId([FromQuery]string workflowId)
        {

            //var result = _commentService.getMemberId(workflowId);

            return null;
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
        public async Task<ActionResult<BaseViewModel<CommentViewPage>>> create([FromBody]CommentCreateViewPage request)
        {

            var result = await _commentService.create(request);

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
        public ActionResult<BaseViewModel<CommentViewPage>> update([FromBody]CommentUpdateViewPage request)
        {

            var result = _commentService.update(request);

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

            var result = _commentService.delete(id);

            return result;
        }

        #endregion
    }
}
