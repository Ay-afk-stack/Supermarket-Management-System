using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

		[Required(ErrorMessage = "*Select a Category")]
		[Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage ="*Enter Product Name")]
        public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "*Enter No. of Product")]
		public int? Quantity { get; set; }

		[Required(ErrorMessage = "*Enter Price of Product")]
		[Range(0, int.MaxValue)]
        public double? Price { get; set; }
        public Category? Category { get; set; }

    }
}
