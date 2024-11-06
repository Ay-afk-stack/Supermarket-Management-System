using System.ComponentModel.DataAnnotations;
using CoreBusiness;
using WebApp.ViewModels.Validations;

namespace WebApp.ViewModels
{
	public class SaleViewModel
	{
		public int SelectedCategoryId {  get; set; }
		public IEnumerable<Category> Categories { get; set; }=new List<Category>();
		public int SelectedProductId { get; set; }
		[Range(1,int.MaxValue)]
		[Display(Name = "Quantity:")]
		[SaleViewModel_EnsureProperQuantity]
		public int QuantityToSell {  get; set; }
	}
}
