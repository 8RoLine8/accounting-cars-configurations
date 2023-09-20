using AccountingCarsConfigurations.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingCarsConfigurations.Data.Repositories
{
    public class ModificationRepository : IRepository<Modification>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ModificationRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Modification> GetAll()
		{
			var result = _dbContext.Modifications.FromSqlRaw("SELECT * FROM read_modifications()").ToList();

			return result;
		}

		public Modification GetById(Guid id)
		{
			var result = _dbContext.Modifications
				.FromSqlRaw($"SELECT * FROM read_modifications('{id}')")
				.FirstOrDefault();

			return result ?? new();
		}

		public Modification Save(Modification item)
		{
			var savedItem = _dbContext.Modifications
							.FromSql($"SELECT * FROM add_modifications({item.Name}, {item.Description}, {item.IdCategory}, {item.Price})")
							.FirstOrDefault();

			_dbContext.SaveChanges();

			return savedItem ?? item;
		}

		public Modification Edit(Modification item)
		{
			var editedItem = _dbContext.Modifications
							.FromSql($"SELECT * FROM update_modifications({item.Id}, {item.Name}, {item.Description}, {item.IdCategory}, {item.Price})")
							.FirstOrDefault();

			_dbContext.SaveChanges();

			return editedItem ?? item;
		}

		public void DeleteById(Guid id)
		{
			_dbContext.Database.ExecuteSqlRaw($"SELECT delete_modifications_by_id('{id}')");
			_dbContext.SaveChanges();
		}
	}
}
