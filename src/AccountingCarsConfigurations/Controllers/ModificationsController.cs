using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Data;
using AccountingCarsConfigurations.Models.ViewModel;
using AccountingCarsConfigurations.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountingCarsConfigurations.Controllers
{
	public class ModificationsController : Controller
	{
		private readonly ModificationRepository _repository;
		private readonly CategoryRepository _categoryRepository;

		public ModificationsController(ModificationRepository repository, CategoryRepository categoryRepository)
		{
			_repository = repository;
			_categoryRepository = categoryRepository;
		}

		/// <summary>
		/// Переход на страницу с информацией о модификациях
		/// </summary>
		/// <returns>Представление с информаци о модификациях</returns>
		public IActionResult Index()
		{
			var viewModel = new ModificationsListViewModel(_repository.GetAll());
			_categoryRepository.GetAll();

			return View("Index", viewModel);
		}

		/// <summary>
		/// Переход на страницу добавления модификации
		/// </summary>
		/// <returns>Представление добавления модификации</returns>
		public IActionResult Create()
		{
			var categories = _categoryRepository.GetAll();

			if (categories.Count == 0) { return View("NullCategoriesError"); }

			var viewModel = new ModificationCreateViewModel(
				categories[0],
				categories
				);

			return View("Create", viewModel);
		}

		/// <summary>
		/// Добавление модификации
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="modification">Объект с данными о модификации</param>
		/// <returns>Переадресация на страницу информации о модификациях</returns>
		public IActionResult Add(Modification modification)
		{
			_repository.Save(modification);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Переход на страницу редактирования информации о модификации
		/// </summary>
		/// <param name="id">Идентификатор модификации</param>
		/// <returns>Представление изменения данных о модификации</returns>
		public IActionResult Update(Guid id)
		{
			var categories = _categoryRepository.GetAll();

			if (categories.Count == 0) { return View("NullCategoriesError"); }

			var currentModification = _repository.GetById(id);

			var viewModel = new ModificationUpdateViewModel(
				currentModification,
				currentModification.IdCategoryNavigation,
				categories
				);

			return View("Update", viewModel);
		}

		/// <summary>
		/// Изменение данных о модификации
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="modification">Объект с данными о модификации</param>
		/// <returns>Переадресация на страницу с информацией о модификации</returns>
		public IActionResult Edit(Modification modification)
		{
			_repository.Edit(modification);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление модификации по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Переадресация на страницу информации о модификациях</returns>
		public IActionResult Delete(Guid id)
		{
			_repository.DeleteById(id);

			return RedirectToAction("Index");
		}
	}
}
