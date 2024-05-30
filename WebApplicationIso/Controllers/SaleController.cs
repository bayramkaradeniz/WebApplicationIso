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
                Products = _mapper.Map<List<ProductViewModel>>(products),
                SelectedCustomer = _mapper.Map<CustomerViewModel>(selectedCustomer)
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SelectProduct(List<int> SelectedProducts, Dictionary<int, int> Quantities, int SelectedCustomerId)
        {
            //if (SelectedProducts != null && Quantities != null)
            //{
            //    var selectedProductViewModels = new List<ProductViewModelForSale>();
            //    foreach (var productId in SelectedProducts)
            //    {
            //        if (Quantities.ContainsKey(productId))
            //        {
            //            var quantity = Quantities[productId];
            //            var product = _context.Products.Find(productId);

            //            if (product != null)
            //            {
            //                selectedProductViewModels.Add(new ProductViewModelForSale
            //                {
            //                    Id = productId,
            //                    Name = product.Name,
            //                    Quantity = quantity
            //                });
            //            }
            //        }
            //    }

            //    if (selectedProductViewModels.Count > 0 && SelectedCustomerId != 0)
            //    {
            //        var customer = _context.Customers.Find(SelectedCustomerId);
            //        if (customer != null)
            //        {
            //            var sale = new Sale
            //            {
            //                DateOfSale = DateTime.Now,
            //                PurchasedProducts = selectedProductViewModels,
            //                Customer = customer,
            //                TotalPrice = CalculateTotalPrice(selectedProductViewModels)
            //            };
            //            _context.Sales.Add(sale);
            //            _context.SaveChanges();
            //        }
            //    }
            //}
            //else
            //{
            //    return View();
            //}

            return RedirectToAction("Index");
        }
        public decimal CalculateTotalPrice(List<ProductViewModelForSale> purchasedProducts)
        {
            decimal totalPrice = 0;

            foreach (var product in purchasedProducts)
            {
                var productPrice = _context.Products.Find(product.Id).Price;
                totalPrice += productPrice * product.Quantity;
            }

            return totalPrice;
        }
    }
}
