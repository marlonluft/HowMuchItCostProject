using Microsoft.AspNetCore.Mvc;

namespace HowMuchItCost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoCurrencyController : BaseController
    {
        [HttpGet("Doge")]
        public IActionResult Doge()
        {
            decimal value = 20.59m;

            return Ok(value);
        }
    }
}
