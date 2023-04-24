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
        }

        //public string DisplayProductName
        //{
        //    get
        //    {
        //        return ProductsInside.First().NameQuantityPrice.ToString();
        //    }
        //}

        //public List<string> ProductsInsideInfo
        //{
        //    get
        //    {
        //        List<string> output = new List<string>();
        //        foreach (var item in ProductsInside)
        //        {
        //            output.Add(item.Product.Name + " " + item.Quantity + " szt. " + (item.Product.Price * item.Quantity).ToString("C"));
        //        }
        //        return output;
        //    }
        //}
    }
}
