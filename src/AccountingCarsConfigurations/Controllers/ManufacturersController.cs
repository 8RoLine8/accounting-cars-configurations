using AccountingCarsConfigurations.Data;
using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Models;
using AccountingCarsConfigurations.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace AccountingCarsConfigurations.Controllers
{
	public class ManufacturersController : Controller
	{
		private readonly ManufacturerRepository _repository;

		public ManufacturersController(ManufacturerRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			Guid id = Guid.Parse("171e54db-bacd-403b-a631-69408d795710");
			var viewModel = new ManufacturerViewModel(
				_repository.GetByID(id),
				_repository.GetAll()
				);

			return View("ManufacturersList", viewModel);
		}

		public IActionResult Add(Manufacturer manufacturer, string number, string email)
		{
			manufacturer.Info = $"{{\"email\":\"{email}\", \"contact_number\":{number}}}";
			_repository.Save(manufacturer);

			return RedirectToAction("Index");
		}
	}
}
