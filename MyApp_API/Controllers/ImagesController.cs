using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApp_API.Handler;

namespace MyApp_API.Controllers
{
    [Route("api/image")]
    [ApiController]
    [Authorize]
    public class ImagesController : ControllerBase
    {
        private readonly IImageHandler _imageHandler;

        public ImagesController(IServiceProvider serviceProvider)
        {

            _imageHandler  = serviceProvider.GetRequiredService<IImageHandler>(); ;
        }

        /// <summary>
        /// Uplaods an image to the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            return await _imageHandler.UploadImage(file);
        }
    }
}