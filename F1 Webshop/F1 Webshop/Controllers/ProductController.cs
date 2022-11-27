using DAL;
using F1_Webshop.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using static Logic.Product;

namespace F1_Webshop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(ProductViewModel productViewModel)
        {
            ProductDAL productdal = new ProductDAL();
            Product product = new Product(productdal);
            productViewModel.products = product.GetProduct(productViewModel.ProductName);
            productViewModel.Price = product.Price;
            return View(productViewModel);
        }

        //public IActionResult GetProduct(ProductViewModel productViewModel, Product.ProductName Productname)
        //{
        //    ProductDAL productdal = new ProductDAL();
        //    Product product = new Product(productdal);
        //    productViewModel.products = product.GetProduct(Productname);
        //    productViewModel.Price = product.Price;
        //    return View(productViewModel);
        //}

        public IActionResult BuyProduct()
        {
            return RedirectToAction("OrderProduct", "Order");
        }
    }
    
}
