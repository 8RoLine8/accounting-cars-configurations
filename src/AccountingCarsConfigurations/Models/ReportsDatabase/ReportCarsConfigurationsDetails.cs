namespace AccountingCarsConfigurations.Models.ReportsDatabase
{
	public partial class ReportCarsConfigurationsDetails
	{
		public string ConfigurationName { get; set; } = null!;

		public decimal ConfigurationPrice { get; set; }

		public string[] ModificationsName { get; set; } = null!;

		public string[] ModificationsDescription { get; set; } = null!;

		public decimal[] ModificationsPrice { get; set; } = null!;
	}
}
