using AccountingCarsConfigurations.Models;

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
			throw new NotImplementedException();
		}

		public Manufacturer GetByID(Guid id)
		{
			throw new NotImplementedException();
		}

		public Manufacturer Save(Manufacturer item)
		{
			throw new NotImplementedException();
		}

		public Manufacturer Edit(Manufacturer item)
		{
			throw new NotImplementedException();
		}

		public void DeleteById(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
