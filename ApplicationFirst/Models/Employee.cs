using System.ComponentModel.DataAnnotations;

namespace ApplicationFirst.Models
{//Entity class ,Model class,POCO(Plain oid C# object)class,Business object class
    public class Employee
    {
        [Key]//this is property the primary key
        public int empid { get; set; }

        [Required(ErrorMessage ="Emp name is required")]
        [StringLength(20,ErrorMessage ="Emp name should be less than 20 characters")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="only number are allowed")]
        [Display(Name ="Employee name")]
        [MinLength(2,ErrorMessage ="Mininum 3 character required")]
        public string? empname { get; set; }
        
        [Required(ErrorMessage ="Age id required")]
        [Range(18,60,ErrorMessage ="Age should be between 18 and 60")]
       // [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="Only Number are Allowed")]
        public int age { get; set; }
        [Required(ErrorMessage = "Salary is required")]
       // [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Number are Allowed")]
        public int salary { get; set; }
        public int isActive { get; set; }
    }
}
