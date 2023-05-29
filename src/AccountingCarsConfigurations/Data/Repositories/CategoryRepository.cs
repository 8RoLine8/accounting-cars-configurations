using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class CategoryRepository : IRepository<Category>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public CategoryRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Category Edit(Category item)
		{
			throw new NotImplementedException();
		}

		public IList<Category> GetAll()
		{
			throw new NotImplementedException();
		}

		public Category GetByID(Guid id)
		{
			throw new NotImplementedException();
		}

		public Category Save(Category item)
		{
			throw new NotImplementedException();
		}
	}
}
