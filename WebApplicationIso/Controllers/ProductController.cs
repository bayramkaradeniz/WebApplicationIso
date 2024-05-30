using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationIso.Models;
using WebApplicationIso.ViewModels;

namespace WebApplicationIso.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;

        private readonly IMapper _mapper;
        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {


            var products = _context.Products.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products)); //Mapping
        }
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1.Ay",1},
                { "3.Ay",3},
                { "6.Ay",6},
                { "12.Ay",12},
            };

            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1.Ay",1},
                { "3.Ay",3},
                { "6.Ay",6},
                { "12.Ay",12},
            };


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(_mapper.Map<Product>(product));
                    _context.SaveChanges();

                    TempData["status"] = "Ürün Başarıyla Eklendi";

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError(String.Empty, "Ürün Kaydedilirken Hata Meydana Geldi.");
                    return View();
                }

            }
            else
            {

                return View();
            }

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id); //Id göndermek İçin
            ViewBag.radioExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1.Ay",1},
                { "3.Ay",3},
                { "6.Ay",6},
                { "12.Ay",12},
            };
           
            return View(_mapper.Map<ProductViewModel>(product));
        }
        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {

            if (!ModelState.IsValid)
            {

                ViewBag.radioExpireValue = updateProduct.Expire;

                ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1.Ay",1},
                { "3.Ay",3},
                { "6.Ay",6},
                { "12.Ay",12},
            };
              
                return View();

            }
            _context.Products.Update(_mapper.Map<Product>(updateProduct));
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarıyla Güncellendi";
            return RedirectToAction("Index");


        }
    }
}
