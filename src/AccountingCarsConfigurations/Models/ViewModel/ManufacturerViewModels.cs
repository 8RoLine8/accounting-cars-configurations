namespace AccountingCarsConfigurations.Models.ViewModel
{
	public record ManufacturerDetailsViewModel(Guid Id, string Name, string Country, string Email, string PhoneNumber);

	public record ManufacturerListViewModel(IList<ManufacturerDetailsViewModel> ManufacturersList);

	public record ManufacturerViewModel(Manufacturer Manufacturer, IList<Manufacturer> ManufacturersList);

}
