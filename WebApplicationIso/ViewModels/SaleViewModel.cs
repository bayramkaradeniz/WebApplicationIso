using WebApplicationIso.Models;

namespace WebApplicationIso.ViewModels
{
    public class SaleViewModel
    {
        public DateTime DateOfSale { get; set; }
        public PurchasedProduct PurchasedProducts { get; set; }
        public Customer? Customer { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
