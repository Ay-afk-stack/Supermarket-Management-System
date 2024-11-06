using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.CategoriesUseCases.DataStorePluginsInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUseCases
{
    public class ViewCategoriesUseCase : IViewCategoriesUseCase
	{
		private readonly ICategoryRepository categoryRepository;

		public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}
		public IEnumerable<Category> Execute()
		{
			return categoryRepository.GetCategories();
		}
	}
}
