using CashLibrary.DataAccess;

namespace CashLibrary
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
