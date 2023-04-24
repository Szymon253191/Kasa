namespace CashLibrary.Models
{
    public class CartElementModel
    {
        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

        public string NameQuantityPrice
        {
            get
            {
                return $"{Product.Name,-10} {Quantity} szt. {(Product.Price * Quantity).ToString("C")}";
            }
        }
    }
}
