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
            Product product = new Product(productViewModel.productname);
            productViewModel.Points = product.CalculatePoints();
            productViewModel.Price = product.CalculatePrice();
            return View(productViewModel);
        }

        public IActionResult Privacy(ProductViewModel productViewModel)
        {
            Product product = new Product(productViewModel.Price);
            productViewModel.Points = product.CalculatePoints();
            return View(productViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}