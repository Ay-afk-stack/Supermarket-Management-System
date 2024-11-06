using CoreBusiness;

namespace UseCases.ProductsUseCases
{
	public interface IViewProductInCategoryUseCase
	{
		IEnumerable<Product> Execute(int categoryId);
	}
}