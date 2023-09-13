using QuickTie.Portal.Extensions;
using System.ComponentModel.DataAnnotations;

namespace QuickTie.Portal.Models
{
    public class RegisterInfo
    {
        [Required(ErrorMessage = "Enter a email")]
        [RegularExpression(RegularExpressions.Email, ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter a last name")]
        public string LastName { get; set; }
    }
}
