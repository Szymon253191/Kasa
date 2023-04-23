using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasaLibrary.Models
{
    public class CartModel
    {
        public List<ProductModel> ProductsInside { get; set; }
        public int Status { get; set; }

        public void Add(ProductModel product)
        {
            ProductsInside.Add(product);
        }
    }
}
