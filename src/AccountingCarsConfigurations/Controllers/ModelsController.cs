using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Models;
using AccountingCarsConfigurations.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountingCarsConfigurations.Controllers
{
	public class ModelsController : Controller
	{
		private readonly ModelRepository _repository;
		private readonly ManufacturerRepository _manufacturerRepository;

		public ModelsController(ModelRepository repository, ManufacturerRepository manufacturerRepository)
		{
			_repository = repository;
			_manufacturerRepository = manufacturerRepository;
		}

		/// <summary>
		/// Переход на страницу с информацией о моделях
		/// </summary>
		/// <returns>Представление с информаци о моделях</returns>
		public IActionResult Index()
		{
			IList<Model> models;
			IList<Manufacturer> manufacturers;

			try 
			{ 
				models = _repository.GetAll();
				manufacturers = _manufacturerRepository.GetAll();
			}
			catch { return View("ServerError"); }

			var viewModelsList = new List<ModelDetailsViewModel>();

			foreach (Model item in models)
			{
				viewModelsList.Add(new ModelDetailsViewModel(
					item,
					manufacturers.Single(m => m.Id == item.IdManufacturer)
					));
			}

			var viewModel = new ModelDetailsListViewModel(viewModelsList);

			return View("Index", viewModel);
		}

		/// <summary>
		/// Переход на страницу добавления модели
		/// </summary>
		/// <returns>Представление добавления модели</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Create()
		{
			IList<Manufacturer> listManufacturers;

			try { listManufacturers = _manufacturerRepository.GetAll(); }
			catch { return View("ServerError"); }

			if (listManufacturers.Count == 0) { return View("NullManufacturersError"); }

			var viewModel = new ModelAndManufacturersListViewModel(
				new(),
				listManufacturers[0],
				listManufacturers
				);

			return View("Create", viewModel);
		}

		/// <summary>
		/// Добавление модели
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="manufacturer">Объект с данными о производителе</param>
		/// <param name="number">Контактный номер телефона</param>
		/// <param name="email">Адрес электронной почты</param>
		/// <returns>Переадресация на страницу информации о производителе</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Add(Model model)
		{
			try { _repository.Save(model); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Переход на страницу редактирования информации о модели
		/// </summary>
		/// <param name="id">Идентификатор модели</param>
		/// <returns>Представление изменения данных о модели</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Update(Guid id) 
		{
			IList<Manufacturer> listManufacturers;
			try { listManufacturers = _manufacturerRepository.GetAll(); }
			catch { return View("ServerError"); }

			if (listManufacturers.Count == 0) { return View("NullManufacturersError"); }

			Model model;
			try { model = _repository.GetById(id); }
			catch { return View("ServerError"); }

			var viewModel = new ModelAndManufacturersListViewModel(
				model,
				listManufacturers[0],
				listManufacturers
				);

			return View("Update", viewModel);
		}

		/// <summary>
		/// Изменение данных о модели
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="model">Объект с данными о модели</param>
		/// <returns>Переадресация на страницу с информацией о моделях</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Edit(Model model)
		{
			try { _repository.Edit(model); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление модели по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Переадресация на страницу информации о моделях</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Delete(Guid id)
		{
			try { _repository.DeleteById(id); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}
	}
}
