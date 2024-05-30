using WebApplicationIso.Models;

namespace WebApplicationIso.ViewModels
{
    public class SelectCustomerViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Adress { get; set; }
        public string Phone { get; set; }
    }
}
