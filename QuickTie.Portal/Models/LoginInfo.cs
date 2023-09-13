using QuickTie.Portal.Extensions;
using System.ComponentModel.DataAnnotations;

namespace QuickTie.Portal.Models
{
    public class LoginInfo
    {
        [Required(ErrorMessage = "Enter a email")]
        [RegularExpression(RegularExpressions.Email, ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
