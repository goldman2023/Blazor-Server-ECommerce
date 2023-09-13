namespace QuickTie.Portal.Models
{
    public class OrderHistory
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string Products { get; set; }
        public string Payment { get; set; }
        public string Status { get; set; }
        public string Total { get; set; }
    }
}
