using Microsoft.AspNetCore.Routing.Matching;

namespace AccountingCarsConfigurations.Models.ViewModel
{
	public record ConfigurationsListViewModel(IList<Configuration> Configurations);
}
