namespace QuickTie.Portal.Models
{
    public class PaymentMethods
    {
        public string CreditCard { get; set; }
        public string PayPal { get; set; }
        public string AmazonPay { get; set; }
        public string AfterPay { get; set; }
        public string PO { get; set; }

        public PaymentMethods()
        {
            CreditCard = "Credit card";
            PayPal = "PayPal";
            AmazonPay = "Amazon pay";
            AfterPay = "Afterpay";
            PO = "Purchase Order(PO)";
        }
    }
}