namespace QuickTie.Portal.Models
{
    public class BillingAddressOptions
    {
        public string SameAsShipping { get; set; }
        public string DifferentAddress { get; set; }

        public BillingAddressOptions()
        {
            SameAsShipping = "Same as shipping address";
            DifferentAddress = "Use a different billing address";
        }
    }
}