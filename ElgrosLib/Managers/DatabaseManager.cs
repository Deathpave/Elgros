using ElgrosLib.Adapters;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ElgrosLib.Managers
{
    public class DatabaseManager
    {
        public IDatabase CreateDatabase(IConfiguration configuration, string databaseName, DatabaseTypes databaseType)
        {
            return DatabaseFactory.CreateDatabase(configuration, databaseName, databaseType);
        }
    }
}
