using AccountingCarsConfigurations.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

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

			RememberUser(login).Wait();
            return RedirectToAction("Index", "Cars");
        }

		public IActionResult Logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Cars");
		}

		private async Task RememberUser(string login)
		{
			var claims = new List<Claim>
			{
				new (ClaimsIdentity.DefaultNameClaimType, login),
				new (ClaimsIdentity.DefaultRoleClaimType, login),
			};
			var id = new ClaimsIdentity(
				claims,
				"ApplicationCookie",
				ClaimsIdentity.DefaultNameClaimType,
				ClaimsIdentity.DefaultRoleClaimType
			);

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(id));
		}
	}
}
