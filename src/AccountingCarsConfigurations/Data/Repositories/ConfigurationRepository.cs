using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class ConfigurationRepository : IRepository<Configuration>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ConfigurationRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Configuration Edit(Configuration item)
		{
			throw new NotImplementedException();
		}

		public IList<Configuration> GetAll()
		{
			throw new NotImplementedException();
		}

		public Configuration GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Configuration Save(Configuration item)
		{
			throw new NotImplementedException();
		}
	}
}
