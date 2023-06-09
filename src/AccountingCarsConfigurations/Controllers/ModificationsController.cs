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
			ModificationsListViewModel viewModel;
			try 
			{ 
				viewModel = new(_repository.GetAll()); 
				_categoryRepository.GetAll();
			}
			catch { return View("ServerError"); }


			return View("Index", viewModel);
		}

		/// <summary>
		/// Переход на страницу добавления модификации
		/// </summary>
		/// <returns>Представление добавления модификации</returns>
		public IActionResult Create()
		{
			IList<Category> categories;
			try { categories = _categoryRepository.GetAll(); }
			catch { return View("ServerError"); }

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
			try { _repository.Save(modification); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Переход на страницу редактирования информации о модификации
		/// </summary>
		/// <param name="id">Идентификатор модификации</param>
		/// <returns>Представление изменения данных о модификации</returns>
		public IActionResult Update(Guid id)
		{
			IList<Category> categories;
			try { categories = _categoryRepository.GetAll(); }
			catch { return View("ServerError"); }

			if (categories.Count == 0) { return View("NullCategoriesError"); }

			Modification currentModification;
			try { currentModification = _repository.GetById(id); }
			catch { return View("ServerError"); }

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
			try { _repository.Edit(modification); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление модификации по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Переадресация на страницу информации о модификациях</returns>
		public IActionResult Delete(Guid id)
		{
			try { _repository.DeleteById(id); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}
	}
}
