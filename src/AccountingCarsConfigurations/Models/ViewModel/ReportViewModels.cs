using AccountingCarsConfigurations.Models.ReportsDatabase;

namespace AccountingCarsConfigurations.Models.ViewModel
{
	public record ReportViewModels(Car СurrentCar, IList<ReportCarsConfigurationsDetails> ConfigurationsDetails);
}
