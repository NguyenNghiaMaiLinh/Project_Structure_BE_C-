using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Send()
        {
            string token = "e0RDhNrnzwU:APA91bEXWSesvqLQ8bh1iRTfGo3qwcsxLOOoGTfB8TnfkiJBQQHr3ODsTJM-k2vL3I3ay8oshsKtzWkTe3dao_IAwpwQm4o3c9gQSCuqnk81hLItpZ2D5_4p40vSDUA9Irh8b17_-0zq";

            PushNotification push = new PushNotification();
            push.NotifyAsync(token, "Linh Test", "Linh Test"); 
            return Ok();
                
        }
    }
}