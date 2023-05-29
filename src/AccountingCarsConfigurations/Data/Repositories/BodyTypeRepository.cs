using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class BodyTypeRepository : IRepository<BodyType>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public BodyTypeRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteById(Guid id)
		{
			throw new NotImplementedException();
		}

		public BodyType Edit(BodyType item)
		{
			throw new NotImplementedException();
		}

		public IList<BodyType> GetAll()
		{
			throw new NotImplementedException();
		}

		public BodyType GetByID(Guid id)
		{
			throw new NotImplementedException();
		}

		public BodyType Save(BodyType item)
		{
			throw new NotImplementedException();
		}
	}
}
