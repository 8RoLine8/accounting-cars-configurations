namespace AccountingCarsConfigurations.Data
{
	public interface IRepository<T>
	{
		IList<T> GetAll();

		T GetByID(Guid id);

		T Save(T item);

		T Edit(T item);

		void DeleteById(Guid id);
	}
}
