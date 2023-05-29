namespace AccountingCarsConfigurations.Models.ViewModel
{
	//public class ManufacturerViewModel
	//{
	//	public Manufacturer manufacturer { get; set; }

	//	public IList<Manufacturer> manufacturersList { get; set; }
	//}

	record ManufacturerViewModel(Manufacturer Manufacturer, IList<Manufacturer> ManufacturersList);
}
