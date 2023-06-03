using AccountingCarsConfigurations.Data;
using AccountingCarsConfigurations.Models.ViewModel;
using AccountingCarsConfigurations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AccountingCarsConfigurations.Data.Repositories;

namespace AccountingCarsConfigurations.Controllers
{
	public class ConfigurationsController : Controller
	{
		private readonly ConfigurationRepository _repository;

		public ConfigurationsController(ConfigurationRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Переход на страницу информации о комплектациях
		/// </summary>
		/// <returns>Представление информации о комплектациях</returns>
		public IActionResult Index()
		{
			var viewModel = new ConfigurationsListViewModel(
				_repository.GetAll()
				);

			return View("Index", viewModel);
		}

		/// <summary>
		/// Переход на страницу добавления комплектации
		/// </summary>
		/// <returns>Представление добавления комплектации</returns>
		public IActionResult Create() => View("Create");

		/// <summary>
		/// Добавление комплектации
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="configuration">Объект с данными о комплектации</param>
		/// <returns>Переадресация на страницу информации о комплекктациях</returns>
		public IActionResult Add(Configuration configuration)
		{
			configuration.Price = 0;
			_repository.Save(configuration);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Переход на страницу редактирования данных о комплектации
		/// </summary>
		/// <param name="id">Идентификатор комплектации</param>
		/// <returns>Представление изменения данных о комплектации</returns>
		public IActionResult Update(Guid id)
		{
			var model = _repository.GetById(id);

			return View("Update", model);
		}

		/// <summary>
		/// Изменение данных о комплектации
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="configuration">Объект с данными о комплектации</param>
		/// <returns>Переадресация на страницу информации о комплектации</returns>
		public IActionResult Edit(Configuration configuration)
		{
			_repository.Edit(configuration);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление комплектации по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Переадресация на страницу информации о комплектациях</returns>
		public IActionResult Delete(Guid id)
		{
			_repository.DeleteById(id);

			return RedirectToAction("Index");
		}
	}
}
