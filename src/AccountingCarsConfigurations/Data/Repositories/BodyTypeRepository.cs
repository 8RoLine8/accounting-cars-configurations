using AccountingCarsConfigurations.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

namespace AccountingCarsConfigurations.Data.Repositories
{
    public class BodyTypeRepository : IRepository<BodyType>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public BodyTypeRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IList<BodyType> GetAll()
		{
			var result = _dbContext.BodyTypes.FromSqlRaw("SELECT * FROM read_body_types()").ToList();

			return result;
		}

		public BodyType GetById(Guid id)
		{
			var result = _dbContext.BodyTypes
				.FromSqlRaw($"SELECT * FROM read_body_types('{id}')")
				.FirstOrDefault();

			return result ?? new();
		}

		public BodyType Save(BodyType item)
		{
			var savedItem = _dbContext.BodyTypes
				.FromSqlRaw($"SELECT * FROM add_body_types('{item.Name}')")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return savedItem ?? item;
		}

		public BodyType Edit(BodyType item)
		{
			var editedItem = _dbContext.BodyTypes
				.FromSqlRaw($"SELECT * FROM update_body_types('{item.Id}', '{item.Name}')")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return editedItem ?? item;
		}

		public void DeleteById(Guid id)
		{
			_dbContext.Database.ExecuteSqlRaw($"SELECT delete_body_types_by_id('{id}')");
			_dbContext.SaveChanges();
		}
	}
}
