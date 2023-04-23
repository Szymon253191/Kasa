using KasaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasaLibrary.DataAccess
{
    public interface IDataConnection
    {
        List<ProductModel> CreateProducts();
    }
}
