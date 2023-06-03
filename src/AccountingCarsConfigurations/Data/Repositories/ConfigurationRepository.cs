using AccountingCarsConfigurations.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class ConfigurationRepository : IRepository<Configuration>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ConfigurationRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Configuration> GetAll()
		{
			var result = _dbContext.Configurations.FromSqlRaw("SELECT * FROM read_configurations()").ToList();

			return result;
		}

		public Configuration GetById(Guid id)
		{
			var result = _dbContext.Configurations
				.FromSqlRaw($"SELECT * FROM read_configurations('{id}')")
				.FirstOrDefault();

			return result ?? new();
		}

		public Configuration Save(Configuration item)
		{
			var savedItem = _dbContext.Configurations
				.FromSql($"SELECT * FROM add_configurations({item.Name}, {item.Description}, {item.Price})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return savedItem ?? item;
		}

		public Configuration Edit(Configuration item)
		{
			var editedItem = _dbContext.Configurations
				.FromSql($"SELECT * FROM update_configurations({item.Id}, {item.Name}, {item.Description}, {item.Price})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return editedItem ?? item;
		}

		public void DeleteById(Guid id)
		{
			_dbContext.Database.ExecuteSqlRaw($"SELECT delete_configurations_by_id('{id}')");
			_dbContext.SaveChanges();
		}
	}
}
