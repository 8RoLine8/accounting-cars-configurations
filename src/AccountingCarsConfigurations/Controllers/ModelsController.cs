using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Models;
using AccountingCarsConfigurations.Models.ViewModel;
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
			IList<Model> models = _repository.GetAll();
			IList<Manufacturer> manufacturers = _manufacturerRepository.GetAll();
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
		public IActionResult Create()
		{
			var listManufacturers = _manufacturerRepository.GetAll();

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
		public IActionResult Add(Model model)
		{
			_repository.Save(model);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Переход на страницу редактирования информации о модели
		/// </summary>
		/// <param name="id">Идентификатор модели</param>
		/// <returns>Представление изменения данных о модели</returns>
		public IActionResult Update(Guid id) 
		{
			var listManufacturers = _manufacturerRepository.GetAll();

			if (listManufacturers.Count == 0) { return View("NullManufacturersError"); }

			var viewModel = new ModelAndManufacturersListViewModel(
				_repository.GetById(id),
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
		public IActionResult Edit(Model model)
		{
			_repository.Edit(model);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление модели по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Переадресация на страницу информации о моделях</returns>
		public IActionResult Delete(Guid id)
		{
			_repository.DeleteById(id);

			return RedirectToAction("Index");
		}
	}
}
