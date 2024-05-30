using WebApplicationIso.Models;

namespace WebApplicationIso.ViewModels
{
    public class ProductCustomerViewModel
    {
        public Customer SelectedCustomer { get; set; }
        public List<Product> Products { get; set; }
        public Dictionary<int, int> SelectedProductQuantities { get; set; }
    }
}
