using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Models;
using AccountingCarsConfigurations.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountingCarsConfigurations.Controllers
{
	public class ConfigurationSetsController : Controller
	{
		private readonly ConfigurationSetRepository _repository;
		private readonly CarRepository _carRepository;
		private readonly ConfigurationRepository _configurationRepository;
		private readonly ModelRepository _modelRepository;
		private readonly BodyTypeRepository _bodyTypeRepository;
		private readonly ManufacturerRepository _manufacturerRepository;

		public ConfigurationSetsController(ConfigurationSetRepository repository,
			CarRepository carRepository, ConfigurationRepository configurationRepository,
			ModelRepository modelRepository, BodyTypeRepository bodyTypeRepository, 
			ManufacturerRepository manufacturerRepository)
		{
			_repository = repository;
			_carRepository = carRepository;
			_configurationRepository = configurationRepository;
			_modelRepository = modelRepository;
			_bodyTypeRepository = bodyTypeRepository;
			_manufacturerRepository = manufacturerRepository;
		}

		/// <summary>
		/// Переход на страницу информации о наборах комплектаций
		/// </summary>
		/// <returns>Представление информации о наборах комплектаций</returns>
		public IActionResult Index()
		{
			IList<ConfigurationSet> listConfigurationSets;
			IList<Car> listCars;
			IList<Configuration> listConfigurations;

			try
			{
				listConfigurationSets = _repository.GetAll();
				listCars = _carRepository.GetAll();
				listConfigurations = _configurationRepository.GetAll();
				_bodyTypeRepository.GetAll();
				_modelRepository.GetAll();
				_manufacturerRepository.GetAll();
			}
			catch { return View("ServerError"); }

			if (listCars.Count == 0) { return View("NullCarsError"); }
			if (listConfigurations.Count == 0) { return View("NullConfigurationsError"); }

			var viewModel = new ConfigurationSetsViewModels(
				listCars[0],
				listConfigurations[0],
				listCars,
				listConfigurations,
				listConfigurationSets
				);

			return View("Index", viewModel);
		}

		/// <summary>
		/// Добавление нового набора комплектации
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="configurationSet"></param>
		/// <returns>Переадресация на страницу информации о наборах комплектаций</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Add(ConfigurationSet configurationSet)
		{
			_repository.Save(configurationSet);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление набора комплектации
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Authorize(Roles = "admin")]
		public IActionResult Delete(Guid id)
		{
			_repository.DeleteById(id);

			return RedirectToAction("Index");
		}
	}
}
