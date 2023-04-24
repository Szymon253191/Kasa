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
                    return products;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd w pobieraniu danych");
                throw;
            }
        }
    }
}
