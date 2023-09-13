namespace QuickTie.Portal.Models
{
    public class ShippingMethods
    {
        public List<ShippingMethodItem> Items { get; set; }
        public ShippingMethods() {
            Items = new List<ShippingMethodItem>
            {
                new ShippingMethodItem { Name="Fast(ish) Shipping (Estimated Delivered in 6-8 Business Days)", Cost=0 },
                new ShippingMethodItem { Name="FedEx Home Delivery (Delivered in 3-5 Business Days)", Cost=11 },
                new ShippingMethodItem { Name="Faster Shipping (Delivered in 2 Business Days if Ordered by 12:30pm EST)", Cost=24  },
                new ShippingMethodItem { Name="Fastest Shipping (Delivered in 1 Business Day if Ordered by 12:30pm EST)", Cost=30  }
            };
        }
    }
}
