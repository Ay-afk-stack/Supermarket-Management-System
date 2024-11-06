using CoreBusiness;

namespace UseCases.ProductsUseCases
{
	public interface IProductRepository
	{
		void AddProduct(Product product);
		void DeleteProduct(int productId);
		Product? GetProductById(int productId, bool loadCategory);
		IEnumerable<Product> GetProductByCategoryId(int categoryId);
		IEnumerable<Product> GetProducts(bool loadCategory);
		void UpdateProduct(int productId, Product product);
	}
}