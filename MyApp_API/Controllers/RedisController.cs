using Microsoft.AspNetCore.Mvc;
using MyApp.Core.Configs;
using StackExchange.Redis;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    { private CacheRedisSetting db = new CacheRedisSetting();

        [HttpGet]
        public ActionResult<string> getDataInQueue()
        {
            return Ok(db.getData());
        }
        [HttpPost]
        public ActionResult<string> setDataInQueue()
        {
            
            return Ok(db.setData());
        }
    }
}