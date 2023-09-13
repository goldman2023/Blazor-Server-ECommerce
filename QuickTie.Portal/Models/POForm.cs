using System.ComponentModel.DataAnnotations;

namespace QuickTie.Portal.Models
{
    public class POForm
    {
        [Required(ErrorMessage = "Enter a PO number.")]
        public string PONumber { get; set; }
    }
}