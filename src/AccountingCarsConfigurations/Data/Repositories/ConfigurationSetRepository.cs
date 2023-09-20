using AccountingCarsConfigurations.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingCarsConfigurations.Data.Repositories
{
    public class ConfigurationSetRepository : IRepository<ConfigurationSet>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ConfigurationSetRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<ConfigurationSet> GetAll()
		{
			var result = _dbContext.ConfigurationSets.FromSqlRaw("SELECT * FROM read_configuration_sets()").ToList();

			return result;
		}

		public ConfigurationSet GetById(Guid id)
		{
			var result = _dbContext.ConfigurationSets
				.FromSqlRaw($"SELECT * FROM read_configuration_sets('{id}')")
				.FirstOrDefault();

			return result ?? new();
		}

		public ConfigurationSet Save(ConfigurationSet item)
		{
			var savedItem = _dbContext.ConfigurationSets
				.FromSql($"SELECT * FROM add_configuration_sets({item.IdCar}, {item.IdConfiguration})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return savedItem ?? item;
		}

		public ConfigurationSet Edit(ConfigurationSet item)
		{
			var editedItem = _dbContext.ConfigurationSets
				.FromSql($"SELECT * FROM update_configuration_sets({item.Id}, {item.IdCar}, {item.IdConfiguration})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return editedItem ?? item;
		}

		public void DeleteById(Guid id)
		{
			_dbContext.Database.ExecuteSqlRaw($"SELECT delete_configuration_sets_by_id('{id}')");
			_dbContext.SaveChanges();
		}
	}
}
