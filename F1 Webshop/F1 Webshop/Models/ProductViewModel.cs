using Logic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using static Logic.Product;

namespace F1_Webshop.Models
{
    public class ProductViewModel
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public double Points { get; set; }
        public ProductName Productname { get; set; }
        public List<Product> products { get; set; }

    }
}

