using ElgrosLib.Adapters;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Managers;
using Microsoft.Extensions.Configuration;

namespace ElgrosLibTester.Setup
{
    /// <summary>
    /// Class for creating a database connection for all test classes
    /// </summary>
    internal class SqlConfigurationSetup
    {
        /// <summary>
        /// Class for creating a database object for testing
        /// </summary>
        /// <returns>IDatabase</returns>
        public static IDatabase SetupDB()
        {
            var inMemorySettings = new Dictionary<string, string?>
            {
                {
                    "ConnectionStrings:DefaultConnection",
                    "Server=10.13.0.123;" +
                    "Database=elgrosdb;" +
                    "Uid=root;Pwd=123;"
                },
            };

            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            DatabaseManager _dbManager = new DatabaseManager();

            IDatabase db = _dbManager.CreateDatabase(config, "door2doordb", DatabaseTypes.MySql);

            return db;
        }
    }
}
