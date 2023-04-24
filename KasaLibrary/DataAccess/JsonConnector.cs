using CashLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace CashLibrary.DataAccess
{
    public class JsonConnector : IDataConnection
    {
        public List<ProductModel> CreateProducts()
        {
            List<ProductModel> products;
            string path = ConfigurationManager.AppSettings["DataFileFullPath"];

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();
                    products = JsonConvert.DeserializeObject<List<ProductModel>>(json);
                    if (!ValidateData(products))
                        new Exception("Bład w spójności danych");
                    return products;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd w pobieraniu danych");
                throw;
            }
        }

        public static bool ValidateData(List<ProductModel> products)
        {
            bool flag = true;
            List<int> Ids = new List<int>();

            foreach (ProductModel product in products)
            {
                if (product.Name == "" || product.Name == null)
                {
                    flag = false;
                    throw new Exception($"Nazwa jednego z produktów jest błędnie zapisana w bazie: {product.Id + " " + product.Name + " " + product.Price}");
                }
                else if (product.Price == null || product.Price < 0f)
                {
                    flag = false;
                    throw new Exception($"Cena jednego z produktów jest błędnie zapisana w bazie: {product.Id + " " + product.Name + " " + product.Price}");
                }
                else if (product.Id == null || Ids.Contains(product.Id))
                {
                    flag = false;
                    throw new Exception($"Numery ID produktu w bazie nie są unikalne lub nie istnieją: {product.Id + " " + product.Name + " " + product.Price}");
                }

                Ids.Add(product.Id);
            }

            return flag;
        }
    }
}
