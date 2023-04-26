using ElgrosLib.Adapters;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Managers;
using Microsoft.Extensions.Configuration;

namespace ElgrosLibTester.Setup
{
    internal class SqlConfigurationSetup
    {

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
