using AccountingCarsConfigurations.Models;
using AccountingCarsConfigurations.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class ManufacturerRepository : IRepository<Manufacturer>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ManufacturerRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Manufacturer> GetAll()
		{
			var result = _dbContext.Manufacturers.FromSqlRaw("SELECT * FROM read_manufacturers()").ToList();

			return result;
		}

		public Manufacturer GetById(Guid id)
		{
			var result = _dbContext.Manufacturers
				.FromSqlRaw($"SELECT * FROM read_manufacturers('{id}')")
				.FirstOrDefault();

			return result ?? new();
		}

		public Manufacturer Save(Manufacturer item)
		{
			var infoParameter = new NpgsqlParameter<string>("@info", item.Info) { NpgsqlDbType = NpgsqlDbType.Jsonb };
			
			var savedItem = _dbContext.Manufacturers
				.FromSqlRaw($"SELECT * FROM add_manufacturers('{item.Name}', '{item.Country}', @info)", infoParameter)
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return savedItem ?? item;
		}

		public Manufacturer Edit(Manufacturer item)
		{
			var infoParameter = new NpgsqlParameter<string>("@info", item.Info) { NpgsqlDbType = NpgsqlDbType.Jsonb };

			var editedItem = _dbContext.Manufacturers
				.FromSqlRaw($"SELECT * FROM update_manufacturers('{item.Id}', '{item.Name}', '{item.Country}', @info)", infoParameter)
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return editedItem ?? item;
		}

		public void DeleteById(Guid id)
		{
			_dbContext.Database.ExecuteSqlRaw($"SELECT delete_manufacturers_by_id('{id}')");
			_dbContext.SaveChanges();
		}
	}
}
