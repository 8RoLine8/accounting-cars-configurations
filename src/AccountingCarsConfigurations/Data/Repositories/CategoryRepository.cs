using AccountingCarsConfigurations.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class CategoryRepository : IRepository<Category>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public CategoryRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Category> GetAll()
		{
			var result = _dbContext.Categories.FromSqlRaw("SELECT * FROM read_categories()").ToList();

			return result;
		}

		public Category GetById(Guid id)
		{
			var result = _dbContext.Categories
				.FromSqlRaw($"SELECT * FROM read_categories('{id}')")
				.FirstOrDefault();

			return result ?? new();
		}

		public Category Save(Category item)
		{
			var savedItem = _dbContext.Categories
				.FromSql($"SELECT * FROM add_categories({item.Name}, {item.Description})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return savedItem ?? item;
		}

		public Category Edit(Category item)
		{
			var editedItem = _dbContext.Categories
				.FromSql($"SELECT * FROM update_categories({item.Id}, {item.Name}, {item.Description})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return editedItem ?? item;
		}


		public void DeleteById(Guid id)
		{
			_dbContext.Database.ExecuteSqlRaw($"SELECT delete_categories_by_id('{id}')");
			_dbContext.SaveChanges();
		}
	}
}
