using CoreBusiness;

namespace UseCases.CategoriesUseCases.DataStorePluginsInterfaces
{
	public interface ICategoryRepository
	{
		void AddCategory(Category category);
		void DeleteCategoryById(int categoryId);
		IEnumerable<Category> GetCategories();
		Category? GetCategoryById(int categoryId);
		void UpdateCategory(int categoryId, Category category);
	}
}