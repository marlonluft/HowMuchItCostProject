using HowMuchItCost.API.ViewModel;
using HowMuchItCost.Library.Enumerador;
using HowMuchItCost.Library.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HowMuchItCost.API.Controllers
{
    /// <summary>
    /// Query cryptocurrency prices
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ResponseCache(CacheProfileName = "Default")]
    public class CryptoCurrencyController : BaseController
    {
        private readonly ICurrencyService _currencyService;

        public CryptoCurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        /// <summary>
        /// Get Dogecoin price in BRL
        /// </summary>
        /// <returns>BRL price</returns>
        [HttpGet("Doge")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultViewModel<decimal>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Doge() =>
            Ok(GetResult(_currencyService.GetBRLPrice(ECurrency.Dogecoin)));
    }
}
