using HowMuchItCost.API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HowMuchItCost.API.Controllers
{
    public class BaseController : Controller
    {
        internal DefaultViewModel<decimal> GetResult(decimal value)
        {
            return new DefaultViewModel<decimal>(value);
        }
    }
}
