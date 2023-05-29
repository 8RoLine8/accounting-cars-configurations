using Microsoft.AspNetCore.Mvc;

namespace AccountingCarsConfigurations.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View("Authorization");
        }
    }
}
