namespace QuickTie.Portal.Models
{
    public class CartItem
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ImageURL { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice => Quantity * PricePerUnit;
    }
}
