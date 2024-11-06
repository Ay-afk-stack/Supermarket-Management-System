using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.CategoriesUseCases.DataStorePluginsInterfaces;

namespace Plugins.DataStore.SQL
{
	public class CategorySQLRepository : ICategoryRepository
	{
		private readonly MarketContext db;

		public CategorySQLRepository(MarketContext db)
		{
			this.db = db;
		}
		public void AddCategory(Category category)
		{
			db.Add(category);
			db.SaveChanges();
		}

		public void DeleteCategoryById(int categoryId)
		{
			var category=db.Categories.Find(categoryId);
			if(category != null)
			{
				db.Categories.Remove(category);
				db.SaveChanges();
			}
			else
			{
				return;
			}
		}

		public IEnumerable<Category> GetCategories()
		{
			return db.Categories.ToList();
		}

		public Category? GetCategoryById(int categoryId)
		{
			return db.Categories.Find(categoryId);
		}

		public void UpdateCategory(int categoryId, Category category)
		{
			if(categoryId!=category.CategoryId) { return; }
			var cat=db.Categories.Find(categoryId);
			if(cat != null)
			{
				cat.Name = category.Name;
				cat.Description = category.Description;
				db.Update(cat);
				db.SaveChanges();
			}

		}
	}
}
