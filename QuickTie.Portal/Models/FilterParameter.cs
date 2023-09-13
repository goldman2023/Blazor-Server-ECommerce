using QuickTie.Data.Models;

namespace QuickTie.Portal.Models
{
    public class FilterParameter
    {
        public float Start { get; set; } = 0;
        public float End { get; set; } = 1000;
        public List<ProductType>? SelectedCategory { get; set; }
    }
}
