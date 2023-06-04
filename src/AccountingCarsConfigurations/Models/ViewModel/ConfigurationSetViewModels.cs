namespace AccountingCarsConfigurations.Models.ViewModel
{
	public record ConfigurationSetsViewModels(Car SelectedCar, Configuration SelectedConfiguration, IList<Car> Cars, IList<Configuration> Configurations, IList<ConfigurationSet> ConfigurationSets);
}
