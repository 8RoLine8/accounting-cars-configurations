using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Data;
using AccountingCarsConfigurations.Models.ViewModel;
using AccountingCarsConfigurations.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountingCarsConfigurations.Controllers
{
	public class CarsController : Controller
	{
		private readonly CarRepository _repository;
		private readonly ModelRepository _modelRepository;
		private readonly BodyTypeRepository _bodyTypeRepository;

		public CarsController(CarRepository repository, ModelRepository modelRepository, BodyTypeRepository bodyTypeRepository)
		{
			_repository = repository;
			_modelRepository = modelRepository;
			_bodyTypeRepository = bodyTypeRepository;
		}

		/// <summary>
		/// Переход на страницу с информацией об автомобилях
		/// </summary>
		/// <returns>Представление с информацией об автомобилях</returns>
		public IActionResult Index()
		{
			IList<Car> cars = _repository.GetAll();
			_modelRepository.GetAll();		// Необходимо для дополнения данными модели Car
			_bodyTypeRepository.GetAll();	// Необходимо для дополнения данными модели Car

			var viewModel = new CarListViewModel(cars);

			return View("Index", viewModel);
		}

		/// <summary>
		/// Переход на страницу с редактированием информации об автомобилях
		/// </summary>
		/// <returns>Представления редактирования информации об автомобилях</returns>
		public IActionResult Create()
		{
			IList<Model> models = _modelRepository.GetAll();
			IList<BodyType> bodyTypes = _bodyTypeRepository.GetAll();

			if (models.Count == 0) { return View("NullModelsError"); }
			if (bodyTypes.Count == 0) { return View("NullBodyTypesError"); }

			var viewModel = new CarCreateViewModel(
				models[0],
				bodyTypes[0],
				models,
				bodyTypes
				);

			return View("Create", viewModel);
		}

		/// <summary>
		/// Добавление автомобиля
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <returns>Переадресация на страницу информации об автомобилях</returns>
		public IActionResult Add(Car car)
		{
			_repository.Save(car);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Переход на страницу изменения данных об аовтомобилях
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Представление изменения данных об автомобилях</returns>
		public IActionResult Update(Guid id) 
		{
			IList<Model> models = _modelRepository.GetAll();
			IList<BodyType> bodyTypes = _bodyTypeRepository.GetAll();

			if (models.Count == 0) { return View("NullModelsError"); }
			if (bodyTypes.Count == 0) { return View("NullBodyTypesError"); }

			var currentCar = _repository.GetById(id);	

			var viewModel = new CarUpdateViewModel(
				currentCar,
				currentCar.IdModelNavigation,
				currentCar.IdBodyTypeNavigation,
				models,
				bodyTypes
				);

			return View("Update", viewModel);
		}

		/// <summary>
		/// Изменение данных об автомобиле
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="car">Объект с данными об автомобиле</param>
		/// <returns>Переадресация на страницу информации об автомобилях</returns>
		public IActionResult Edit(Car car)
		{
			_repository.Edit(car);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление автомобиля по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Переадресация на страницу информации об автомобилях</returns>
		public IActionResult Delete(Guid id)
		{
			_repository.DeleteById(id);

			return RedirectToAction("Index");
		}

		public IActionResult NullModelsError() => View();

		public IActionResult NullBodyTypesError() => View();

	}
}
