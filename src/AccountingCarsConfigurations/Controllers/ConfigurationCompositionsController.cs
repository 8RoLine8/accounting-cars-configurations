using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Models;
using AccountingCarsConfigurations.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AccountingCarsConfigurations.Controllers
{
	public class ConfigurationCompositionsController : Controller
	{
		private readonly ConfigurationCompositionRepository _repository;
		private readonly ConfigurationRepository _configurationRepository;
		private readonly ModificationRepository _modificationRepository;
		private readonly CategoryRepository _categoryRepository;

		public ConfigurationCompositionsController(ConfigurationCompositionRepository repository, ModificationRepository modificationRepository, CategoryRepository categoryRepository, ConfigurationRepository configurationRepository)
		{
			_repository = repository;
			_modificationRepository = modificationRepository;
			_categoryRepository = categoryRepository;
			_configurationRepository = configurationRepository;
		}

		/// <summary>
		/// Переход на страницу составов комплектаций
		/// </summary>
		/// <returns>Представление состава комплектаций</returns>
		public IActionResult Index()
		{
			var listConfigurationCompositions = _repository.GetAll();
			var listConfigurations = _configurationRepository.GetAll();
			var listModifications = _modificationRepository.GetAll();
			_categoryRepository.GetAll();

			if (listModifications.Count == 0) { return View("NullModificationsError"); }
			if (listConfigurations.Count == 0) { return View("NullConfigurationsError"); }

			var viewModel = new ConfigurationCompositionViewModel(
				listModifications[0],
				listConfigurations[0],
				listModifications,
				listConfigurations,
				listConfigurationCompositions
				);

			return View("Index", viewModel);
		}

		/// <summary>
		/// Добавление состава комплектации
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="configurationComposition"></param>
		/// <returns>Переадресация на страницу информации о составах комплектаций</returns>
		public IActionResult Add(ConfigurationComposition configurationComposition) 
		{
			_repository.Save(configurationComposition);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление модификации из состава комплектации
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Переадресация на страницу информации о составах комплектаций</returns>
		public IActionResult Delete(Guid id)
		{
			_repository.DeleteById(id);
			
			return RedirectToAction("Index");
		}
	}
}
