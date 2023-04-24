using CashLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLibrary.DataAccess
{
    public interface IDataConnection
    {
        List<ProductModel> CreateProducts();
    }
}
