using System.ComponentModel.DataAnnotations;

namespace ClothesStoreWebsite.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please, enter your email")]
        [EmailAddress(ErrorMessage = "Make sure you have entered the correct email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter your password")]
        [MinLength(5, ErrorMessage = "Use 5 characters or more for your password")]
        public string Password { get; set; }
    }
}
