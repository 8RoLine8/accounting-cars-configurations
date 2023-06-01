using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class LogRepository : IRepository<Log>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public LogRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Log Edit(Log item)
		{
			throw new NotImplementedException();
		}

		public IList<Log> GetAll()
		{
			throw new NotImplementedException();
		}

		public Log GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Log Save(Log item)
		{
			throw new NotImplementedException();
		}
	}
}
