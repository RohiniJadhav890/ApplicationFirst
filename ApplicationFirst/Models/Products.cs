using System.ComponentModel.DataAnnotations;

namespace ApplicationFirst.Models
{
    public class Products
    {
        [Key]
        public int Pid { get; set; }
        [Required(ErrorMessage = "name is required")]
        [StringLength(20, ErrorMessage = "name should be less than 20 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only number are allowed")]
        [Display(Name = "Product name")]
        [MinLength(2, ErrorMessage = "Mininum 3 character required")]
        public string? Pname { get; set; }

        [Required(ErrorMessage = "Price id required")]
        [Range(1800, 60000, ErrorMessage = "Age should be between 1800 and 60000")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Total { get; set; }

        public int isActive { get; set; }
    }
}
