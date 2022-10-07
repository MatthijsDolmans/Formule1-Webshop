namespace F1_Webshop.Models
{
    public class ProductViewModel
    {
        
            public decimal Price { get; set; }
            public double Points { get; set; }
            public string productname { get; set; }
        public enum ProductName
        {
            Tshirt,
            Cap,

        }
    }
}

