using ElgrosLib.Adapters;
using ElgrosLib.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ElgrosLib.Factories
{
    /// <summary>
    /// Factory that handles the creation of IDatabase objects
    /// </summary>
    public class DatabaseFactory
    {
        #region Create Database
        /// <summary>
        /// Creates a database instance
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="databaseName"></param>
        /// <param name="databaseType"></param>
        /// <returns>IDatabase</returns>
        public static IDatabase CreateDatabase(IConfiguration configuration, string databaseName, DatabaseTypes databaseType)
        {
            IDatabase database = null;
            switch (databaseType)
            {
                case DatabaseTypes.MySql:
                    database = new MySqlDatabase(configuration, databaseName);
                    break;
            }
            return database;
        }
        #endregion
    }
}
