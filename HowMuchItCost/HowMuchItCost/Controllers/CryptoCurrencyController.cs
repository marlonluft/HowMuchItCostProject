using HowMuchItCost.Library.Enumerador;
using HowMuchItCost.Library.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HowMuchItCost.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoCurrencyController : BaseController
    {
        private readonly ICurrencyService _currencyService;

        public CryptoCurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("Doge")]
        public IActionResult Doge() =>
            Ok(_currencyService.GetBRLPrice(ECurrency.Dogecoin));
    }
}
