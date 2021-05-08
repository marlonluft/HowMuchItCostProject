using Microsoft.AspNetCore.Mvc;

namespace HowMuchItCost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Pong");
        }
    }
}
