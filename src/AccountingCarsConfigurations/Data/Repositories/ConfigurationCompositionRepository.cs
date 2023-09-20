using AccountingCarsConfigurations.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingCarsConfigurations.Data.Repositories
{
    public class ConfigurationCompositionRepository : IRepository<ConfigurationComposition>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ConfigurationCompositionRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<ConfigurationComposition> GetAll()
		{
			var result = _dbContext.ConfigurationCompositions.FromSqlRaw("SELECT * FROM read_configuration_compositions()").ToList();

			return result;
		}

		public ConfigurationComposition GetById(Guid id)
		{
			var result = _dbContext.ConfigurationCompositions
				.FromSqlRaw($"SELECT * FROM read_configuration_compositions('{id}')")
				.FirstOrDefault();

			return result ?? new();
		}

		public ConfigurationComposition Save(ConfigurationComposition item)
		{
			var savedItem = _dbContext.ConfigurationCompositions
				.FromSql($"SELECT * FROM add_configuration_compositions({item.IdModification}, {item.IdConfiguration})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return savedItem ?? item;
		}

		public ConfigurationComposition Edit(ConfigurationComposition item)
		{
			var editedItem = _dbContext.ConfigurationCompositions
				.FromSql($"SELECT * FROM update_configuration_compositions({item.Id}, {item.IdModification}, {item.IdConfiguration})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return editedItem ?? item;
		}

		public void DeleteById(Guid id)
		{
			_dbContext.Database.ExecuteSqlRaw($"SELECT delete_configuration_compositions_by_id('{id}')");
			_dbContext.SaveChanges();
		}
	}
}
