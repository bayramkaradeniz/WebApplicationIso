using WebApplicationIso.Models;

namespace WebApplicationIso.ViewModels
{
    public class SaleProductViewModel
    {
        public int SaleProductId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
