using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Product
    {

       
        private ProductName productName { get; set; }
        private Sizes Size { get; set; }
        public decimal Price { get; set; }
        private int Stock { get; set; }
        private double Points { get; set; }
        private bool HasEarlyAccess { get; set; }

        private readonly Iproduct _product;
        public enum Sizes
        {
            Small,
            Medium,
            Large,
            XL
        }
        public enum ProductName
        {
            Tshirt,
            Cap,
            Trousers
        }
        public Product(Iproduct product)
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
            if (HasEarlyAccess == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetStock()
        {
            Stock = 10;
            return Stock;
        }
        public double CalculatePoints()
        {
            Points = (double)Price * 10;
            Points = Math.Round(Points, 0);
            return Points;
        }

        public decimal GetPrice()
        {
            _product.GetPrice(ProductName.Cap);
            return Price;
        }
    }
}
