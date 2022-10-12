using F1_Webshop.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace F1_Webshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ProductViewModel productViewModel)
        {
            Product product = new Product(productViewModel.Price, productViewModel.Productname, productViewModel.Stock, productViewModel.Points);
            productViewModel.Price = product.CalculatePrice();
            productViewModel.Points = product.CalculatePoints();
            productViewModel.Stock = product.GetStock();
            return View(productViewModel);
        }

        public IActionResult Privacy(ProductViewModel productViewModel)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}