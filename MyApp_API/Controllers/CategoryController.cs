using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;


        public CategoryController(IServiceProvider serviceProvider)
        {
            _categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }

        #region
        /// <summary>
        /// GetMyAllBanner
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>linhnnm</author>
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<CategoryViewPage>>> GetMyAllCategory([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _categoryService.GetAllCategory(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }
        #endregion


    }
}
