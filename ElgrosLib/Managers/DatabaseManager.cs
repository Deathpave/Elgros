using ElgrosLib.Adapters;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ElgrosLib.Managers
{
    /// <summary>
    /// Manager class for handling Database objects
    /// </summary>
    public class DatabaseManager
    {
        /// <summary>
        /// Creates a database object from factory
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="databaseName"></param>
        /// <param name="databaseType"></param>
        /// <returns>IDatabase</returns>
        public IDatabase CreateDatabase(IConfiguration configuration, string databaseName, DatabaseTypes databaseType)
        {
            return DatabaseFactory.CreateDatabase(configuration, databaseName, databaseType);
        }
    }
}
