namespace AccountingCarsConfigurations.Models.ViewModel
{
	public record ConfigurationCompositionViewModel(Modification SelectedModification, Configuration SelectedConfiguration, 
		IList<Modification> Modifications, IList<Configuration> Configurations, IList<ConfigurationComposition> ConfigurationCompositions);
}
