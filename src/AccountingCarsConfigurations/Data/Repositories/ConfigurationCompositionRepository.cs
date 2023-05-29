using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class ConfigurationCompositionRepository : IRepository<ConfigurationComposition>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ConfigurationCompositionRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteById(Guid id)
		{
			throw new NotImplementedException();
		}

		public ConfigurationComposition Edit(ConfigurationComposition item)
		{
			throw new NotImplementedException();
		}

		public IList<ConfigurationComposition> GetAll()
		{
			throw new NotImplementedException();
		}

		public ConfigurationComposition GetByID(Guid id)
		{
			throw new NotImplementedException();
		}

		public ConfigurationComposition Save(ConfigurationComposition item)
		{
			throw new NotImplementedException();
		}
	}
}
