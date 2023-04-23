using KasaLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;

namespace KasaLibrary.DataAccess
{
    public class JsonConnector : IDataConnection
    {
        public List<ProductModel> CreateProducts()
        {
            List<ProductModel> products;
            string path = ConfigurationManager.AppSettings["ProjectPath"] + "\\Data\\Baza.json";

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<ProductModel>>(json);
                return products;
            }
        }
    }
}
