using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCases
{
	public class ViewSelectedProductUseCase : IViewSelectedProductUseCase
	{
		private readonly IProductRepository productRepository;

		public ViewSelectedProductUseCase(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}
		public Product? Execute(int productId, bool loadCategory = false)
		{
			return productRepository.GetProductById(productId, loadCategory);

		}
	}
}
