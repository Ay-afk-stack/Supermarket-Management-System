using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UseCases.ProductsUseCases;

namespace Plugins.DataStore.SQL
{
	public class ProductSQLRepository : IProductRepository
	{
		private readonly MarketContext db;

		public ProductSQLRepository(MarketContext db)
		{
			this.db = db;
		}
		public void AddProduct(Product product)
		{
			db.Add(product);
			db.SaveChanges();
		}

		public void DeleteProduct(int productId)
		{
			var prod=db.Products.Find(productId);
			if(prod != null)
			{
				db.Remove(prod);
				db.SaveChanges();
			}
			return;
		}

		public IEnumerable<Product> GetProductByCategoryId(int categoryId)
		{
			return db.Products.Where(x => x.CategoryId==categoryId).ToList();
		}

		public Product? GetProductById(int productId, bool loadCategory=false)
		{
			if (loadCategory)
			{
				return db.Products
					.Include(p => p.Category)
					.FirstOrDefault(p=>p.ProductId==productId);
			}
			else
			{
				return db.Products.FirstOrDefault(p=>p.ProductId==productId);
			}
		}

		public IEnumerable<Product> GetProducts(bool loadCategory=false)
		{
			if (loadCategory)
			{
				return db.Products
					.Include(p => p.Category)
					.OrderBy(p => p.CategoryId).ToList();
			}
			else
			{
				return db.Products
					.OrderBy(p => p.CategoryId).ToList();
			};
		}

		public void UpdateProduct(int productId, Product product)
		{
			if(productId!=product.ProductId) return;
			var prod=db.Products.FirstOrDefault(p=>p.ProductId==productId);
			if(prod!=null)
			{
				prod.CategoryId = product.CategoryId;
				prod.Name= product.Name;
				prod.Price = product.Price;
				prod.Quantity = product.Quantity;
				db.Update(prod);
				db.SaveChanges();
			}
			return;
		}
	}
}
