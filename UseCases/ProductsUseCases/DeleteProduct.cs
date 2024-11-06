using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCases
{
	public class DeleteProduct : IDeleteProduct
	{
		private readonly IProductRepository productRepository;

		public DeleteProduct(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}
		public void Execute(int productId)
		{
			productRepository.DeleteProduct(productId);
		}
	}
}
