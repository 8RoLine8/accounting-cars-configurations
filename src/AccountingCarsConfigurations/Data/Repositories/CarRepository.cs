using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class CarRepository : IRepository<Car>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public CarRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Car Edit(Car item)
		{
			throw new NotImplementedException();
		}

		public IList<Car> GetAll()
		{
			throw new NotImplementedException();
		}

		public Car GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Car Save(Car item)
		{
			throw new NotImplementedException();
		}
	}
}
