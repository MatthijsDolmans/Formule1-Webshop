using Logic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using static Logic.Helpers.ProductNameEnum;
using static Logic.ProductCollection;

namespace F1_Webshop.Models
{
    public class ProductViewModel
    {
        public List<Product> products { get; set; }
        public decimal Price { get; set; }

        public ProductName ProductName { get; set; }
    }
}

