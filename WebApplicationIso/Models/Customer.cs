namespace WebApplicationIso.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Adress { get; set; }
        public string Phone { get; set; }
        public Decimal? TotalSalesPrice { get; set; }
        public ICollection<Sale>? Sales { get; set; }
        public ICollection<PurchasedProduct>? PurchasedProducts { get; set; }
    }
}
