using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="*Please Fill the Name Field!")]
        public string Name { get; set; }=string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
