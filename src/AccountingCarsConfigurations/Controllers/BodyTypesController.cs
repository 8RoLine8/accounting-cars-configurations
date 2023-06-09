using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Controllers
{
    public class BodyTypesController : Controller
	{
		private readonly BodyTypeRepository _repository;

		public BodyTypesController(BodyTypeRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Переход на страницу информации о типах кузова
		/// </summary>
		/// <returns>Представление информации о типах кухова</returns>
		public IActionResult Index()
		{
			BodyTypeListViewModel viewModel;

			try
			{
				viewModel = new BodyTypeListViewModel(
				_repository.GetAll()
				);
			}
			catch { return View("ServerError"); }

			return View("Index", viewModel);
		}

		/// <summary>
		/// Переход на страницу добавления типа кузова
		/// </summary>
		/// <returns>Представление добавления типа кузова</returns>
		public IActionResult Create() => View("Create");

		/// <summary>
		/// Добавление типа кузова
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="bodyType">Объект с данными о типе кузова</param>
		/// <returns>Переадресация на страницу информации о типах кузова</returns>
		public IActionResult Add(BodyType bodyType)
		{
			try { _repository.Save(bodyType); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Переход на страницу редактирования данных о типе кузова
		/// </summary>
		/// <param name="id">Идентификатор типа кузова</param>
		/// <returns>Представление изменения данных о типах кузова</returns>
		public IActionResult Update(Guid id)
		{
			BodyType model;

			try { model = _repository.GetById(id); }
			catch { return View("ServerError"); }

			return View("Update", model);
		}

		/// <summary>
		/// Изменение данных о типе кузова
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="bodyType">Объект с данными о типе кузова</param>
		/// <returns>Переадресация на страницу информации о типах кузова</returns>
		public IActionResult Edit(BodyType bodyType)
		{
			try { _repository.Edit(bodyType); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление типа кузова по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Переадресация на страницу информации о типах кузова</returns>
		public IActionResult Delete(Guid id)
		{
			try { _repository.DeleteById(id); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}
	}
}
