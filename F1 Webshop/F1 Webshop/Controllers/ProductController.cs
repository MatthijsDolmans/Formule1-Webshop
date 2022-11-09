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
            ProductDAL productdal = new ProductDAL();
            Product product = new Product(productdal);
            productViewModel.products = product.GetProduct();
            return View(productViewModel);
        }
    }
}
