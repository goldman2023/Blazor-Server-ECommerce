using QuickTie.Data.Models;

namespace QuickTie.Portal.Models
{
    public class ProductTypeInfo
    {
        public ProductType Type { get; set; }
        public string DisplayName { get; set; }
        public long Count { get; set; }
    }
}
