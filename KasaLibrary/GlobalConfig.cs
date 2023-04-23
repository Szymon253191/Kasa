using KasaLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasaLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections()
        {
            JsonConnector connector = new JsonConnector();
            Connection = connector;
        }
    }
}
