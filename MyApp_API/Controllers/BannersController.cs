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
    public class BannersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBannerService _bannerService;


        public BannersController(IServiceProvider serviceProvider)
        {
            _bannerService = serviceProvider.GetRequiredService<IBannerService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

        }
        [HttpGet]
        public ActionResult<BaseViewModel<PagingResult<BannerViewPage>>> GetMyUser([FromQuery]BasePagingRequestViewModel request)
        {
            request.SetDefaultPage();

            var result = _bannerService.GetAllBanner(request);

            this.HttpContext.Response.StatusCode = (int)result.StatusCode;

            return result;
        }

    }
}
