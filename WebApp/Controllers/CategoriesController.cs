using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.CategoriesUseCases;
using UseCases.Interfaces;

namespace WebApp.Controllers
{
    [Authorize(Policy ="Inventory")]
    public class CategoriesController : Controller
    {
		private readonly IAddCategoryUseCase addCategoryUseCase;
		private readonly IViewCategoriesUseCase viewCategoriesUseCase;
		private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;
		private readonly IEditCategoryUseCase editCategoryUseCase;
		private readonly IDeleteCategoryUseCase deleteCategoryUseCase;

		public CategoriesController(
            IAddCategoryUseCase addCategoryUseCase,
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedCategoryUseCase viewSelectedCategoryUseCase,
            IEditCategoryUseCase editCategoryUseCase,
            IDeleteCategoryUseCase deleteCategoryUseCase)
        {
			this.addCategoryUseCase = addCategoryUseCase;
			this.viewCategoriesUseCase = viewCategoriesUseCase;
			this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
			this.editCategoryUseCase = editCategoryUseCase;
			this.deleteCategoryUseCase = deleteCategoryUseCase;
		}
        public IActionResult Index()
        {
            var categories= viewCategoriesUseCase.Execute();
            return View(categories);
        }
        public IActionResult Add()
        {
			ViewBag.Action = "Add";
			return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                addCategoryUseCase.Execute(category);
				return RedirectToAction(nameof(Index));
			}
            return View(category);
           
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";
            var category=viewSelectedCategoryUseCase.Execute(categoryId:id.HasValue?id.Value:0);
            return View(category); 
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
				editCategoryUseCase.Execute(category.CategoryId, category);
				return RedirectToAction(nameof(Index));
			}
            return View(category);
        }
        public IActionResult Delete(int? id)
        {
            deleteCategoryUseCase.Execute(categoryId:id.HasValue?id.Value:0);
            return RedirectToAction(nameof(Index));
        }
    }
}
