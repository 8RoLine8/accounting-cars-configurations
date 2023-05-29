using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class ConfigurationSetRepository : IRepository<ConfigurationSet>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ConfigurationSetRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteById(Guid id)
		{
			throw new NotImplementedException();
		}

		public ConfigurationSet Edit(ConfigurationSet item)
		{
			throw new NotImplementedException();
		}

		public IList<ConfigurationSet> GetAll()
		{
			throw new NotImplementedException();
		}

		public ConfigurationSet GetByID(Guid id)
		{
			throw new NotImplementedException();
		}

		public ConfigurationSet Save(ConfigurationSet item)
		{
			throw new NotImplementedException();
		}
	}
}
