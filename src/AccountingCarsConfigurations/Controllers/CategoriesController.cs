using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Models.ViewModel;
using AccountingCarsConfigurations.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountingCarsConfigurations.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly CategoryRepository _repository;

		public CategoriesController(CategoryRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Переход на страницу информации о категориях
		/// </summary>
		/// <returns>Представление информации о категориях</returns>
		public IActionResult Index()
		{
			CategoriesListViewModel viewModel;

			try
			{
				viewModel = new CategoriesListViewModel(
				_repository.GetAll()
				);
			}
			catch { return View("ServerError"); }

			return View("Index", viewModel);
		}

		/// <summary>
		/// Переход на страницу добавления категории
		/// </summary>
		/// <returns>Представление добавления категории</returns>
		public IActionResult Create() => View("Create");

		/// <summary>
		/// Добавление категории
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="category">Объект с данными о категории</param>
		/// <returns>Переадресация на страницу информации о категориях</returns>
		public IActionResult Add(Category category)
		{
			try { _repository.Save(category); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Переход на страницу редактирования данных о категориях
		/// </summary>
		/// <param name="id">Идентификатор категории</param>
		/// <returns>Представление изменения данных о категории</returns>
		public IActionResult Update(Guid id)
		{
			Category model;

			try { model = _repository.GetById(id); }
			catch { return View("ServerError"); }

			return View("Update", model);
		}

		/// <summary>
		/// Изменение данных о категории
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="category">Объект с данными о категориях</param>
		/// <returns>Переадресация на страницу информации о категориях</returns>
		public IActionResult Edit(Category category)
		{
			try { _repository.Edit(category); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление категории по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Переадресация на страницу информации о категориях</returns>
		public IActionResult Delete(Guid id)
		{
			try { _repository.DeleteById(id); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}
	}
}
