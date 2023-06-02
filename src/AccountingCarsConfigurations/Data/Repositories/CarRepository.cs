using AccountingCarsConfigurations.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingCarsConfigurations.Data.Repositories
{
	public class CarRepository : IRepository<Car>
	{
		private readonly AccountingCarsConfigurationsContext _dbContext;

		public CarRepository(AccountingCarsConfigurationsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Car> GetAll()
		{
			var result = _dbContext.Cars.FromSqlRaw("SELECT * FROM read_cars()").ToList();

			return result;
		}

		public Car GetById(Guid id)
		{
			var result = _dbContext.Cars
				.FromSqlRaw($"SELECT * FROM read_cars('{id}')")
				.FirstOrDefault();

			return result ?? new();
		}

		public Car Save(Car item)
		{
			var savedItem = _dbContext.Cars
				.FromSql($"SELECT * FROM add_cars({item.IdModel}, {item.IdBodyType}, {item.ProductionYear})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return savedItem ?? item;
		}

		public Car Edit(Car item)
		{
			var editedItem = _dbContext.Cars
				.FromSql($"SELECT * FROM update_cars({item.Id}, {item.IdModel}, {item.IdBodyType}, {item.ProductionYear})")
				.FirstOrDefault();

			_dbContext.SaveChanges();

			return editedItem ?? item;
		}

		public void DeleteById(Guid id)
		{
			_dbContext.Database.ExecuteSqlRaw($"SELECT delete_cars_by_id('{id}')");
			_dbContext.SaveChanges();
		}
	}
}
