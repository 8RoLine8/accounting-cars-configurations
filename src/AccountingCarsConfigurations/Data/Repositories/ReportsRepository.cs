using AccountingCarsConfigurations.Models;
using AccountingCarsConfigurations.Models.ReportsDatabase;
using Microsoft.EntityFrameworkCore;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class ReportsRepository
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ReportsRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<ReportCarsConfigurationsDetails> GetAll(Guid idCar)
		{
			var result = _dbContext.ReportCarsConfigurationsDetails
				.FromSql($"SELECT * FROM cars_configurations_report({idCar})")
				.ToList();

			return result;
		}
	}
}
