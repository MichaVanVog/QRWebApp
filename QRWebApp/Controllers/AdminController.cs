using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QR.Db;
using QR.Db.Models;
using QRWebApp.Models;

namespace QRWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsInDbRepository productsRepository;
        private readonly IMapper mapper;

        public AdminController(IProductsInDbRepository productsRepository, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            var models = mapper.Map<List<ProductViewModel>>(products);
            return View(models);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel model)
        {
            Product product;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.ProductionDate <= DateOnly.FromDateTime(DateTime.Now))
            {
                if (model.DaysMonths == DateViewModel.Days)
                {
                    var date = model.ProductionDate.AddDays(model.TermDays);
                    if (date < DateOnly.FromDateTime(DateTime.Now))
                    {
                        ModelState.AddModelError("TermDays", "Необходимо заполнить правильно срок или срок годности истек");
                        return View(model);
                    }
                    model.ExpireDate = date;
                    product = mapper.Map<Product>(model);
                    productsRepository.Add(product);
                    return RedirectToAction("Index", "Admin");
                }
                if (model.DaysMonths == DateViewModel.Months)
                {
                    var date = model.ProductionDate.AddMonths(model.TermDays);
                    if (date < DateOnly.FromDateTime(DateTime.Now))
                    {
                        ModelState.AddModelError("TermDays", "Необходимо заполнить правильно срок или срок годности истек");
                        return View(model);
                    }
                    model.ExpireDate = date;
                    product = mapper.Map<Product>(model);
                    productsRepository.Add(product);
                    return RedirectToAction("Index", "Admin");
                }
            }
            if (model.ProductionDate > DateOnly.FromDateTime(DateTime.Now))
            {
                model.ExpireDate = model.ProductionDate;
            }
            product = mapper.Map<Product>(model);
            productsRepository.Add(product);
            return RedirectToAction("Index", "Admin");
        }
    }
}
