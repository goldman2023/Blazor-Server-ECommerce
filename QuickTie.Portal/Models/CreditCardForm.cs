using QuickTie.Portal.Extensions;
using System.ComponentModel.DataAnnotations;


namespace QuickTie.Portal.Models
{
    public class CreditCardForm
    {
        [Required(ErrorMessage = "Enter a card number")]
        [RegularExpression(RegularExpressions.CardNumber, ErrorMessage = "Enter a valid card number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Enter your name exactly as it’s written on your card")]
        public string NameOnCard { get; set; }

        [Required(ErrorMessage = "Enter a card expiry date")]
        [RegularExpression(RegularExpressions.ExpirationDate, ErrorMessage = "Enter a valid card expiry date")]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = "Enter the CVV or security code on your card")]
        [RegularExpression(RegularExpressions.SecurityCode, ErrorMessage = "Enter the CVV or security code on your card")]
        public string SecurityCode { get; set; }
    }
}
