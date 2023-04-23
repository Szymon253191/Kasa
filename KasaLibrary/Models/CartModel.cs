using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasaLibrary.Models
{
    public class CartModel
    {
        public List<CartElementModel> ProductsInside { get; set; }
        public int Status { get; set; }
        public float TotatPrice
        {
            get
            {
                return ProductsInside.Sum(element => element.Product.Price * element.Quantity);
            }
        }

        public CartModel() 
        {
            ProductsInside = new List<CartElementModel>();
            Status = 0;
        }

        public string ProductsInsideInfo
        {
            get
            {
                return $"{ ProductsInside } ";
            }
        }
    }
}
