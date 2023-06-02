namespace AccountingCarsConfigurations.Models.ViewModel
{
	public record ModelDetailsViewModel(Model Model, Manufacturer Manufacturer);

	public record ModelDetailsListViewModel(IList<ModelDetailsViewModel> ModelDetails);

	public record ModelAndManufacturersListViewModel(Model Model, Manufacturer SelectedManufacturer, IList<Manufacturer> Manufacturers);
}
