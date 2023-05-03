using ElgrosLib.Interfaces;
using ElgrosLib.Logs;
using System.Data.Common;
using System.Data.SqlClient;

namespace ElgrosLib.Repositories
{
    /// <summary>
    /// Repository class for handling database calls for Log objects
    /// </summary>
    internal class LogRepository : ILogRepository
    {
        private readonly IDatabase _database;

        internal LogRepository(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Creates a Log entity in the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns>True or False</returns>
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

        /// <summary>
        /// Deletes a Log entity from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns>True or False</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteAsync(DatabaseLog deleteEntity)
        {
            throw new Exception("Logs are only allowed to be created");
        }

        /// <summary>
        /// Method for getting all logs from the database
        /// </summary>
        /// <returns>IEnumerable of all Logs</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<DatabaseLog>> GetAllAsync()
        {
            throw new Exception("Logs are only allowed to be created");
        }

        /// <summary>
        /// Method for getting specific log from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DatabaseLog</returns>
        /// <exception cref="Exception"></exception>
        public async Task<DatabaseLog> GetByIdAsync(int id)
        {
            throw new Exception("Logs are only allowed to be created");
        }

        /// <summary>
        /// Method for updating a Log entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns>True or False</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateAsync(DatabaseLog updateEntity)
        {
            throw new Exception("Logs are only allowed to be created");
        }
    }
}
