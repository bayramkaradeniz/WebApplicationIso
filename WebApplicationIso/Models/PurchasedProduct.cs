using WebApplicationIso.ViewModels;

namespace WebApplicationIso.Models
{
    public class PurchasedProduct
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<Product> ProductList { get; set; }
    }
}
