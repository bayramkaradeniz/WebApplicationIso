using WebApplicationIso.ViewModels;

namespace WebApplicationIso.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime DateOfSale { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<PurchasedProduct>? PurchasedProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
