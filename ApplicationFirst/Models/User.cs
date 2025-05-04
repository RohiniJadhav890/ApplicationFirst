using System.ComponentModel.DataAnnotations;

namespace ApplicationFirst.Models
{
    public class User
    {
        [Required(ErrorMessage ="User name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]

        public string? Password{ get; set; }

        [Required(ErrorMessage = "Confirm Password  is required")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password do not match")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Emailis required")]
       // [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Email should be in proper like yourname@domain.com")]

        public string? UserEmail { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? PhoneNumber { get; set; }
        [CreditCard]
        public string? DebitCard { get; set; }
    }
}
