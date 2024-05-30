using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplicationIso.Models;
using WebApplicationIso.ViewModels;

namespace WebApplicationIso.Controllers
{
    public class SaleController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SaleController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SelectCustomer()
        {
            var customers = _context.Customers.ToList();

            return View(_mapper.Map<List<SelectCustomerViewModel>>(customers));
        }

        [HttpGet]
        public IActionResult SelectProduct(int SelectedCustomerId)
        {
            var selectedCustomer = _context.Customers.Find(SelectedCustomerId);
            var products = _context.Products.ToList();

            var viewModel = new ProductCustomerViewModel
            {
                Products = products,
                SelectedCustomer = selectedCustomer
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddSale(ProductCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Model doğrulama hatası varsa, aynı view'a geri dön
                return View("SelectProduct", model);
            }

            // Sale oluşturma işlemi
            var sale = new Sale
            {
                Date = DateTime.Now,
                CustomerId = model.SelectedCustomer.Id,
                TotalSalePrice = 0, // Toplam satış fiyatını burada hesaplayabilirsiniz
                SaleProducts = new List<SaleProduct>()
            };

            foreach (var product in model.Products)
            {
                var productFromDb = _context.Products.Find(product.Id);
                if (productFromDb == null)
                {
                    // Ürün bulunamazsa hata mesajı ile aynı view'a geri dön
                    ModelState.AddModelError("", $"Product with ID {product.Id} not found.");
                    return View("SelectProduct", model);
                }

                var quantity = model.SelectedProductQuantities[product.Id];
                if (quantity <= 0 || quantity > productFromDb.Stock)
                {
                    // Geçersiz miktar için hata mesajı ile aynı view'a geri dön
                    ModelState.AddModelError("", $"Invalid quantity for product {productFromDb.Name}.");
                    return View("SelectProduct", model);
                }

                // Satış ürünü oluşturma ve satışa ekleme
                var saleProduct = new SaleProduct
                {
                    ProductId = product.Id,
                    Quantity = quantity,
                    Price = productFromDb.Price
                };
                sale.TotalSalePrice += quantity * productFromDb.Price;
                sale.SaleProducts.Add(saleProduct);
            }

            // Veritabanına kaydetme
            _context.Sales.Add(sale);
            _context.SaveChanges();

            // Başarılı olduğunda Index sayfasına yönlendir
            return RedirectToAction("Index");
        }
    }
}
