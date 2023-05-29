using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class ModelRepository : IRepository<Model>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ModelRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Model Edit(Model item)
		{
			throw new NotImplementedException();
		}

		public IList<Model> GetAll()
		{
			throw new NotImplementedException();
		}

		public Model GetByID(Guid id)
		{
			throw new NotImplementedException();
		}

		public Model Save(Model item)
		{
			throw new NotImplementedException();
		}
	}
}
