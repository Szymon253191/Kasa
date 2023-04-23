using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KasaLibrary.Models
{
    public class CartElementModel
    {
        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

        public string NameAndQuantity
        {
            get
            {
                return $"{ Product.Name } { Quantity }";
            }
        }
    }
}
