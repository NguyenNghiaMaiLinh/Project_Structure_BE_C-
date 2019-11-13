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
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;


        public ProductController(IServiceProvider serviceProvider)
        {
            _productService = serviceProvider.GetRequiredService<IProductService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }

        #region GetAllProduct
        /// <summary>
        /// GetMyAllBanner
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>linhnnm</author>
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<ProductViewPage>>> GetAllProduct([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _productService.GetAllProduct(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }
        #endregion

        #region GetAllProductByCategoryId
        /// <summary>
        /// GetMyAllBanner
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>linhnnm</author>
        [HttpGet("GetAllProductByCategoryId")]
        public ActionResult<BaseViewModel<PagingResult<ProductViewPage>>> GetAllProductByCategoryId([FromQuery]ProductPagingRequestModel request)
        {
            request.SetDefaultPage();

            var result = _productService.GetAllProductByCategoryId(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }
        #endregion

        #region GetProductById
        /// <summary>
        /// GetMyAllBanner
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>linhnnm</author>
        [HttpGet("{id}")]
        public ActionResult<BaseViewModel<ProductDetailViewPage>> GetProductById(string id)
        {

            var result = _productService.GetProductById(id);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }
        #endregion


        #region create

        /// <summary>
        /// create
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ProductViewPage</returns>
        /// <author>Linhnnm</author>
        [HttpPost("create")]
        public ActionResult create([FromBody]ProductCreateViewPage request)
        {
            var entity = _productService.create(request);
            if (entity.Data != null)
            {
                return Ok(entity);
            }
            else
            {

                return BadRequest(new BaseViewModel<ProductViewPage>
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

