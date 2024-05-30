using NuGet.Protocol.Core.Types;
using WebApplicationIso.Models;

namespace WebApplicationIso.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Adress { get; set; }
        public string Phone { get; set; }
        public Decimal? TotalSalesPrice { get; set; }
        public int? PurchasedProductId { get; set; }
    }
}
