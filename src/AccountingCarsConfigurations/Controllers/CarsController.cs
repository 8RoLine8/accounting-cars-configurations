using Microsoft.AspNetCore.Mvc;

namespace AccountingCarsConfigurations.Controllers
{
	public class CarsController : Controller
	{
		public IActionResult Index()
		{


			return View("CarsList");
		}
	}
}
