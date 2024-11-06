using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCases
{
	public class EditProductUseCase : IEditProductUseCase
	{
		private readonly IProductRepository productRepository;

		public EditProductUseCase(IProductRepository product)
		{
			this.productRepository = product;
		}
		public void Execute(int productId, Product product)
		{
			productRepository.UpdateProduct(productId, product);
		}
	}
}
