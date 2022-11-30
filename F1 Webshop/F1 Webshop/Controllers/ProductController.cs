using DAL;
using F1_Webshop.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using static Logic.ProductCollection;

namespace F1_Webshop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(ProductViewModel productViewModel,string button,string loaded)
        {
            if (!string.IsNullOrEmpty(loaded))
            {
                GetProductInformation(productViewModel);
            }
            if(!string.IsNullOrEmpty(button))
            {
                ProductDAL productdal = new ProductDAL();
                Order order = new Order();
                order.OrderProduct(GetProductInformation(productViewModel),productdal);
                return RedirectToAction("Index", "Order");
            }
            return View(productViewModel);
        }

        public List<Product> GetProductInformation(ProductViewModel productviewmodel)
        {
            ProductDAL productdal = new ProductDAL();
            ProductCollection product = new ProductCollection(productdal);
            productviewmodel.products = product.GetProduct(productviewmodel.ProductName);
            
            return productviewmodel.products;
        }
    }
    
}
