using AccountingCarsConfigurations.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class ModelRepository : IRepository<Model>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ModelRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Model> GetAll()
		{
			var result = _dbContext.Models.FromSqlRaw("SELECT * FROM read_models()").ToList();

			return result;
		}

		public Model GetById(Guid id)
		{
			var result = _dbContext.Models
				.FromSqlRaw($"SELECT * FROM read_models('{id}')")
				.FirstOrDefault();

			return result ?? new();
		}

		public Model Save(Model item)
		{
			var savedItem = _dbContext.Models
				.FromSql($"SELECT * FROM add_models({item.Name}, {item.IdManufacturer})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return savedItem ?? item;
		}

		public Model Edit(Model item)
		{
			var editedItem = _dbContext.Models
				.FromSql($"SELECT * FROM update_models({item.Id}, {item.Name}, {item.IdManufacturer})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return editedItem ?? item;
		}

		public void DeleteById(Guid id)
		{
			_dbContext.Database.ExecuteSqlRaw($"SELECT delete_models_by_id('{id}')");
			_dbContext.SaveChanges();
		}

	}
}
