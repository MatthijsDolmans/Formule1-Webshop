using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Product
    {
        public ProductName productName { get; private set; }
        public Sizes Size { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public double Points { get; private set; }
        private bool HasEarlyAccess { get; set; }

        private readonly IproductDAL _product;
        public enum Sizes
        {
            Small,
            Medium,
            Large,
            XL
        }
        public enum ProductName
        {
            Cap,
            Tshirt,
            Trousers
        }
        public Product(IproductDAL product)
        {
            _product = product;
        }
        public Product()
        {
        }
        public Product(decimal prize, ProductName productname, int stock)
        {
            Price = prize;
            productName = productname;
            Stock = stock;
        }
        public bool CanProductBeBought()
        {
            if (IsProductInStock() == true & ProductNeedsEarlyaccess() == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsProductInStock()
        {
            if(Stock <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ProductNeedsEarlyaccess()
        {
            if (HasEarlyAccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double CalculatePoints()
        {
            Points = (double)Price * 10;
            Points = Math.Round(Points, 0);
            return Points;
        }

        public List<Product> GetProduct(ProductName productname)
        {
           var item = _product.GetProduct(productname);
            return item;
        }
    }
}
