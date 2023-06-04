using Microsoft.AspNetCore.Mvc;

namespace AccountingCarsConfigurations.Controllers
{
	public class MainController : Controller
	{
		public IActionResult Index()
		{
			return View("Index");
		}
	}
}
