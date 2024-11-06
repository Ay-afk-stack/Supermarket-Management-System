using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;
using CoreBusiness;
using UseCases.ProductsUseCases;
using UseCases.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
	[Authorize(policy:"Inventory")]
	public class ProductsController : Controller
	{
		private readonly IAddProductUseCase addProductUseCase;
		private readonly IDeleteProduct deleteProduct;
		private readonly IViewProductsUseCase viewProductsUseCase;
		private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
		private readonly IEditProductUseCase editProductUseCase;
		private readonly IViewCategoriesUseCase viewCategoriesUseCase;

		public ProductsController(
			IAddProductUseCase addProductUseCase,
			IDeleteProduct deleteProduct,
			IViewProductsUseCase viewProductsUseCase,
			IViewSelectedProductUseCase viewSelectedProductUseCase,
			IEditProductUseCase editProductUseCase,
			IViewCategoriesUseCase viewCategoriesUseCase
			)
		{
			this.addProductUseCase = addProductUseCase;
			this.deleteProduct = deleteProduct;
			this.viewProductsUseCase = viewProductsUseCase;
			this.viewSelectedProductUseCase = viewSelectedProductUseCase;
			this.editProductUseCase = editProductUseCase;
			this.viewCategoriesUseCase = viewCategoriesUseCase;
		}
		public IActionResult Index()
		{
			var products = viewProductsUseCase.Execute(loadCategory:true);
			return View(products);
		}
		public IActionResult Add()
		{
			ProductViewModel model = new ProductViewModel()
			{
				Categories=viewCategoriesUseCase.Execute()
			};

			return View(model);
		}
		[HttpPost]
		public IActionResult Add(ProductViewModel model)
		{
			if (ModelState.IsValid)
			{
				addProductUseCase.Execute(model.Product);
				return RedirectToAction(nameof(Index));
			}
			model.Categories= viewCategoriesUseCase.Execute();
			return View(model);
		}
		public IActionResult Edit(int id)
		{
			var prods = new ProductViewModel()
			{
				Product = viewSelectedProductUseCase.Execute(id) ?? new Product(),
				Categories = viewCategoriesUseCase.Execute()
			};
			return View(prods);
		}
		[HttpPost]
		public IActionResult Edit(ProductViewModel productViewModel)
		{
			if (ModelState.IsValid)
			{
				editProductUseCase.Execute(productViewModel.Product.ProductId, productViewModel.Product);
				return RedirectToAction(nameof(Index));
			}
			productViewModel.Categories = viewCategoriesUseCase.Execute();
			return View(productViewModel);
		}
		public IActionResult Delete(int id)
		{
			deleteProduct.Execute(id);
			return RedirectToAction(nameof(Index));
		}

		
	}
}
