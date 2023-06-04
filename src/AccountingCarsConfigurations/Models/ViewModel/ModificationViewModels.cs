namespace AccountingCarsConfigurations.Models.ViewModel
{
	public record ModificationsListViewModel(IList<Modification> Modifications);

	public record ModificationCreateViewModel(Category SelectedCategory, IList<Category> Categories);

	public record ModificationUpdateViewModel(Modification Modification, Category SelectedCategory, IList<Category> Categories);
}
