using ElgrosLib.Interfaces;
using ElgrosLib.Logs;
using System.Data.Common;
using System.Data.SqlClient;

namespace ElgrosLib.Repositories
{
    internal class LogRepository : ILogRepository
    {
        private readonly IDatabase _database;

        public LogRepository(IDatabase database)
        {
            _database = database;
        }

        public async Task<bool> CreateAsync(DatabaseLog createEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spCreateLog");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@message",createEntity.Message},
                {"@messageType",createEntity.MessageType },
                {"@date",createEntity.TimeStamp}
            };

            // Get datareader with result from dbcommand
            using var dataReader = await _database.ExecuteQueryAsync(command, parameters);
            dataReader.Read();
            affectedRows = dataReader.RecordsAffected;
            await _database.CloseConnectionAsync();

            if (affectedRows > 0)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteAsync(DatabaseLog deleteEntity)
        {
            throw new Exception("Logs are only allowed to be created");
        }

        public async Task<IEnumerable<DatabaseLog>> GetAllAsync()
        {
            throw new Exception("Logs are only allowed to be created");
        }

        public async Task<DatabaseLog> GetByIdAsync(int id)
        {
            throw new Exception("Logs are only allowed to be created");
        }

        public async Task<bool> UpdateAsync(DatabaseLog updateEntity)
        {
            throw new Exception("Logs are only allowed to be created");
        }
    }
}
