using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Interfaces;
using UseCases.ProductsUseCases;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
	[Authorize(Policy ="Cashier")]
	public class SalesController : Controller
	{
		private readonly IViewCategoriesUseCase viewCategoriesUseCase;
		private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
		private readonly ISellProductUseCase sellProductUseCase;
		private readonly IViewProductInCategoryUseCase viewProductInCategoryUseCase;

		public SalesController(
			IViewCategoriesUseCase viewCategoriesUseCase,
			IViewSelectedProductUseCase viewSelectedProductUseCase,
			ISellProductUseCase sellProductUseCase,
			IViewProductInCategoryUseCase viewProductInCategoryUseCase
			)
		{
			this.viewCategoriesUseCase = viewCategoriesUseCase;
			this.viewSelectedProductUseCase = viewSelectedProductUseCase;
			this.sellProductUseCase = sellProductUseCase;
			this.viewProductInCategoryUseCase = viewProductInCategoryUseCase;
		}
		public IActionResult Index()
		{
			var salesviewmodel = new SaleViewModel()
			{
				Categories = viewCategoriesUseCase.Execute()
			};
			return View(salesviewmodel);
		}
		public IActionResult SellProductPartial(int productId)
		{
			var products = viewSelectedProductUseCase.Execute(productId);
			return PartialView("_SellProducts", products);
		}
		public IActionResult Sell(SaleViewModel sale)
		{
			if(ModelState.IsValid)
			{
				//Sell 
				sellProductUseCase.Execute("Cashier1", sale.SelectedProductId, sale.QuantityToSell);
			}
			var products=viewSelectedProductUseCase.Execute(sale.SelectedProductId);
			sale.SelectedCategoryId = (products?.CategoryId==null)?0:products.CategoryId.Value;
			sale.Categories = viewCategoriesUseCase.Execute();
			return View("Index",sale);
		}
		public IActionResult ProductByCategoryIdPartial(int CategoryId)
		{
			var product = viewProductInCategoryUseCase.Execute(CategoryId);
			return PartialView("_Products", product);
		}
	}
}
