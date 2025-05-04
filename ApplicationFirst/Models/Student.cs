using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace ApplicationFirst.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "name is required")]
        [StringLength(20, ErrorMessage = "name should be less than 20 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only number are allowed")]
        [Display(Name = "Student name")]
        [MinLength(2, ErrorMessage = "Mininum 3 character required")]
        public string? Sname { get; set; }

        [Required(ErrorMessage = "Age id required")]
        [Range(18, 60, ErrorMessage = "Age should be between 18 and 60")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Marks is required")]
        public int Marks { get; set; }

       public int isActive { get; set; }
    }
}
