using WebApplicationIso.ViewModels;

namespace WebApplicationIso.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalSalePrice { get; set; }

        // Satışın ürün listesi
        public ICollection<SaleProduct> SaleProducts { get; set; }
    }

}
