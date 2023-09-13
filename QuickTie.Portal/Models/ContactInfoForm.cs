using QuickTie.Portal.Extensions;
using System.ComponentModel.DataAnnotations;

namespace QuickTie.Portal.Models
{
    public class ContactInfoForm
    {
        [Required(ErrorMessage = "Enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter a email.")]
        [RegularExpression(RegularExpressions.Email, ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter a city.")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Enter a state.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter a valid zip code.")]
        [RegularExpression(RegularExpressions.ZipCode, ErrorMessage = "Invalid zip code")]
        public string ZipCode { get; set; }

        public string? Company { get; set; }

        public string Country { get; set; }

        public string Apartment { get; set; }

        public string Phone { get; set; }

        public bool EmailOffers { get; set; } = false;
    }
}