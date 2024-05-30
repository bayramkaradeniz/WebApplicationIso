using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplicationIso.Models;
using WebApplicationIso.ViewModels;

namespace WebApplicationIso.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(_mapper.Map<List<CustomerViewModel>>(customers));
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CustomerViewModel customer)
        {
            customer.PurchasedProductId = null;
            _context.Customers.Add(_mapper.Map<Customer>(customer));
            _context.SaveChanges();

            TempData["status"] = "Müşteri Başarıyla Eklendi";

            return RedirectToAction("Index");
        }
    }
}
