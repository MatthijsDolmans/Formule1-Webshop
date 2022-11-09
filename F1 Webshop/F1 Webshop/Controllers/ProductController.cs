using DAL;
using F1_Webshop.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace F1_Webshop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(ProductViewModel productViewModel)
        {
            Product product = new Product(new ProductDAL());
            productViewModel.Price = product.GetPrice();
            productViewModel.Points = product.CalculatePoints();
            productViewModel.Stock = product.GetStock();

            return View(productViewModel);
        }
    }
}
