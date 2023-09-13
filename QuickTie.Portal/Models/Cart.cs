namespace QuickTie.Portal.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }
        public int TotalCount => Items.Sum(item => item.Quantity);
        public decimal SubTotalPrice => Items.Sum(item => item.TotalPrice);
    }
}