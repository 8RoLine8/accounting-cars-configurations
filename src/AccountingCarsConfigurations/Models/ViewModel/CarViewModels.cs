using AccountingCarsConfigurations.Models;

namespace AccountingCarsConfigurations.Models.ViewModel
{
    public record CarListViewModel(IList<Car> Cars);

	public record CarCreateViewModel(Model SelectedModel, BodyType SelectedBodyType, IList<Model> Models, IList<BodyType> BodyTypes);

	public record CarUpdateViewModel(Car Car, Model SelectedModel, BodyType SelectedBodyType, IList<Model> Models, IList<BodyType> BodyTypes);
}
