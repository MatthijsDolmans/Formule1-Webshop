using DAL;
using F1_Webshop.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using static Logic.Product;

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
                Order order = new Order();
                order.OrderProduct(GetProductInformation(productViewModel));
            }
            return View(productViewModel);
        }

        public List<Product> GetProductInformation(ProductViewModel productviewmodel)
        {
            ProductDAL productdal = new ProductDAL();
            Product product = new Product(productdal);
            productviewmodel.products = product.GetProduct(productviewmodel.ProductName);
            
            return productviewmodel.products;
        }
    }
    
}
