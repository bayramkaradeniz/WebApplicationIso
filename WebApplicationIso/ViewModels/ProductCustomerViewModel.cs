using WebApplicationIso.Models;

namespace WebApplicationIso.ViewModels
{
    public class ProductCustomerViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public CustomerViewModel SelectedCustomer { get; set; }
    }
}
