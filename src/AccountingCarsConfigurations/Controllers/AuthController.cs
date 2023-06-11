using AccountingCarsConfigurations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AccountingCarsConfigurations.Controllers
{
    public class AuthController : Controller
    {
        private readonly AccountingCarsConfigurationsContext _dbContext;

		public AuthController(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
        {
            return View("Auth");
        }

        public IActionResult Login(string login, string password)
        {
            string newConnetionString = $"Server=localhost;Port=5432;Database=accounting_cars_configurations;Username={login};Password={password}";

			_dbContext.Database.SetConnectionString(newConnetionString);
            bool connectionAttempt = _dbContext.Database.CanConnect();

            if (!connectionAttempt) { return View("LoginInvalid"); }

            return RedirectToAction("Index", "Cars");
        }
    }
}
