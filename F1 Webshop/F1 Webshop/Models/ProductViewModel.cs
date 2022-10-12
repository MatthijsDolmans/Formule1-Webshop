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
        public List<SelectListItem> Productnames { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Cap", Text = "Cap" },
            new SelectListItem { Value = "Tshirt", Text = "Tshirt" },
            new SelectListItem { Value = "Trousers", Text = "Trousers"  },
        };
        public List<SelectListItem> Sizes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Small", Text = "Small" },
            new SelectListItem { Value = "Medium", Text = "Medium" },
            new SelectListItem { Value = "Large", Text = "Large"  },
            new SelectListItem { Value = "XL", Text = "XL"  },
        };
    }
}

