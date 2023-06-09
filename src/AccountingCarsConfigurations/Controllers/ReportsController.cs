using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Models;
using AccountingCarsConfigurations.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AccountingCarsConfigurations.Controllers
{
	public class ReportsController : Controller
	{
		private readonly ReportsRepository _repository;
		private readonly CarRepository _carRepository;
		private readonly ModelRepository _modelRepository;
		private readonly ManufacturerRepository _manufacturerRepository;
		private readonly ModificationRepository _modificationRepository;

		public ReportsController(ReportsRepository repository, CarRepository carRepository, ModelRepository modelRepository, ManufacturerRepository manufacturerRepository, ModificationRepository modificationRepository)
		{
			_repository = repository;
			_carRepository = carRepository;
			_modelRepository = modelRepository;
			_manufacturerRepository = manufacturerRepository;
			_modificationRepository = modificationRepository;
		}

		public IActionResult Index()
		{
			IList<Car> listCars;
			try
			{
				listCars = _carRepository.GetAll();
				_manufacturerRepository.GetAll(); // Для детализации моделей (Не удалять!)
				_modelRepository.GetAll();        // Для детализации моделей (Не удалять!)
			}
			catch { return View("ServerError"); }

			if (listCars.Count == 0) { return View("NullCarsError"); }

			var viewModel = new CarViewModel(
				listCars[0],
				listCars
				);

			return View("Index", viewModel);
		}

		public IActionResult CarConfigurationsDetailsReport(Guid idCar)
		{
			ReportViewModels viewModel;

			try
			{
				_modelRepository.GetAll();          // Для детализации моделей (Не удалять!)
				_manufacturerRepository.GetAll();   // Для детализации моделей (Не удалять!)
			
				viewModel = new ReportViewModels(
					_carRepository.GetById(idCar),
					_repository.GetAll(idCar)
				);
			}
			catch { return View("ServerError"); }

			if (viewModel.ConfigurationsDetails.Count == 0) { return View("NullReportError"); }

			return View("CarConfigurationsDetailsReport", viewModel);
		}
	}
}
