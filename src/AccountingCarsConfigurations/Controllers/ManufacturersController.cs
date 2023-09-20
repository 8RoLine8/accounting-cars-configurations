using AccountingCarsConfigurations.Data;
using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Models;
using AccountingCarsConfigurations.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AccountingCarsConfigurations.Controllers
{
	public class ManufacturersController : Controller
	{
		private readonly ManufacturerRepository _repository;

		public ManufacturersController(ManufacturerRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Позволяет конвертировать обычную модель в модель-представления
		/// <br/>
		/// Из-за особенности реализации бд, пришлось разделять jsonb
		/// поле модели, на два string поля
		/// </summary>
		/// <param name="manufacturer">Модель с данными</param>
		/// <returns>Модель-представления с детализированными данными</returns>
		private static ManufacturerDetailsViewModel ConvertToManufacturerDetailsViewModel(Manufacturer manufacturer)
		{
			JsonDocument jsonInfo = JsonDocument.Parse(manufacturer.Info);

			Console.WriteLine(jsonInfo.RootElement.GetProperty("email").GetString() ?? "unknown");
			Console.WriteLine(jsonInfo.RootElement.GetProperty("contact_number").GetString() ?? "unknown");

			return new(
				manufacturer.Id,
				manufacturer.Name,
				manufacturer.Country,
				jsonInfo.RootElement.GetProperty("email").GetString() ?? "unknown",
				jsonInfo.RootElement.GetProperty("contact_number").GetString() ?? "unknown"
				);
		}

		/// <summary>
		/// Переход на страницу информации о производителях
		/// </summary>
		/// <returns>Представление информации о производителе</returns>
		public IActionResult Index()
		{
			IList<Manufacturer> listManufacturers;
			List<ManufacturerDetailsViewModel> tempList = new();

			try { listManufacturers = _repository.GetAll(); }
			catch { return View("ServerError"); }

			foreach (var item in listManufacturers)
			{
				tempList.Add(ConvertToManufacturerDetailsViewModel(item));
			}

			var viewModel = new ManufacturerListViewModel(tempList);

			return View("Index", viewModel);
		}

		/// <summary>
		/// Переход на страницу добавления производителя
		/// </summary>
		/// <returns>Представление добавления производителя</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Create() => View("Create");

		/// <summary>
		/// Добавление производителя
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="manufacturer">Объект с данными о производителе</param>
		/// <param name="number">Контактный номер телефона</param>
		/// <param name="email">Адрес электронной почты</param>
		/// <returns>Переадресация на страницу информации о производителе</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Add(Manufacturer manufacturer, string number, string email)
		{
			/* Контактный номер и почта представлены в виде одного jsonb,
			 * поэтому над ними требуется произвести некоторые манипуляции 
			 * для корректной передачи в базу данных */

			manufacturer.Info = $"{{\"email\":\"{email}\", \"contact_number\":\"{number}\"}}";

			try { _repository.Save(manufacturer); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Переход на страницу редактирования данных о производителе
		/// </summary>
		/// <param name="id">Идентификатор производителя</param>
		/// <returns>Представление изменения данных о производителе</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Update(Guid id)
		{
			ManufacturerDetailsViewModel viewModel;

			try { viewModel = ConvertToManufacturerDetailsViewModel(_repository.GetById(id)); }
			catch { return View("ServerError"); }

			return View("Update", viewModel);
		}

		/// <summary>
		/// Изменение данных о производителе
		/// <br/>
		/// Метод взаимодействует с репозиторием
		/// </summary>
		/// <param name="manufacturer">Объект с данными о производителе</param>
		/// <returns>Переадресация на страницу информации о производителе</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Edit(ManufacturerDetailsViewModel manufacturer)
		{
			/* Контактный номер и почта представлены в виде одного jsonb,
			 * поэтому над ними требуется произвести некоторые манипуляции 
			 * для корректной передачи в базу данных */

			string infoJson = $"{{\"email\":\"{manufacturer.Email}\", \"contact_number\":\"{manufacturer.PhoneNumber}\"}}";

			Manufacturer editedManufacturer;

			try { editedManufacturer = _repository.GetById(manufacturer.Id); }
			catch { return View("ServerError"); }

			editedManufacturer.Name = manufacturer.Name;
			editedManufacturer.Country = manufacturer.Country;
			editedManufacturer.Info = infoJson;

			try { _repository.Edit(editedManufacturer); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Удаление производителя по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор</param>
		/// <returns>Переадресация на страницу информации о производителе</returns>
		[Authorize(Roles = "admin")]
		public IActionResult Delete(Guid id)
		{
			try { _repository.DeleteById(id); }
			catch { return View("ServerError"); }

			return RedirectToAction("Index");
		}
	}
}
