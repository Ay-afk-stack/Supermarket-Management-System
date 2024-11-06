using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCases
{
	public class ViewProductInCategoryUseCase : IViewProductInCategoryUseCase
	{
		private readonly IProductRepository productRepository;

		public ViewProductInCategoryUseCase(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}
		public IEnumerable<Product> Execute(int categoryId)
		{
			return productRepository.GetProductByCategoryId(categoryId);
		}
	}
}
