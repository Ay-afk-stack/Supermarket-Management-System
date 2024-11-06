using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="*Please Fill the Name Field!")]
        public string Name { get; set; }=string.Empty;
        public string? Description { get; set; } = string.Empty;

        //navigation property for EF core
        public List<Product>? Products { get; set; }
    }
}
