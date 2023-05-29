using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class ModificationRepository : IRepository<Modification>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public ModificationRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Modification Edit(Modification item)
		{
			throw new NotImplementedException();
		}

		public IList<Modification> GetAll()
		{
			throw new NotImplementedException();
		}

		public Modification GetByID(Guid id)
		{
			throw new NotImplementedException();
		}

		public Modification Save(Modification item)
		{
			throw new NotImplementedException();
		}
	}
}
