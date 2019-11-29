using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;
using MyApp.Core.ViewModel.ViewPage;
using MyApp.Service;
using MyApp.Service.Service;
using System.Collections.Generic;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SendController : ControllerBase
    {
        [HttpPost]
        public IActionResult Send([FromBody] UserDeleteViewPage token)
        {

            PushNotification push = new PushNotification();
            push.NotifyAsync(token.Id, "Linh Test", "Linh Test"); 
            return Ok();
                
        }
    }
}