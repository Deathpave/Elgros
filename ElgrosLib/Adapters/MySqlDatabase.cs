using ElgrosLib.Factories;
using ElgrosLib.Logs;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;

namespace ElgrosLib.Adapters
{
    /// <summary>
    /// Database class for handling MySqlDatabase specific actions
    /// </summary>
    internal class MySqlDatabase : Database
    {
        public MySqlDatabase(IConfiguration configuration, string databaseName) : base(configuration, databaseName)
        {
            base.Connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        /// <summary>
        /// Executes sql command
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="sqlParams"></param>
        /// <returns>DbDataReader</returns>
        public override async Task<DbDataReader> ExecuteQueryAsync(DbCommand sqlCommand, IDictionary<string, object> sqlParams = null)
        {
            try
            {
                using MySqlCommand commandObj = new()
                {
                    CommandText = sqlCommand.CommandText,
                    CommandType = sqlCommand.CommandType,
                    Connection = (MySqlConnection)base.Connection,
                };

                if (sqlParams != null)
                {
                    AddSqlParamsToSqlCommand(commandObj, sqlParams);
                }

                await base.OpenConnectionAsync();

                return await commandObj.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                LogFactory.CreateLog(LogTypes.File, $"Failed to execute sql command due to {e.Message}", MessageTypes.Error).WriteLog();
                return await Task.FromResult<DbDataReader?>(null);
            }
        }

        /// <summary>
        /// Adds parameters in an IDictionary to a MySqlCommand object
        /// </summary>
        /// <param name="commandObj"></param>
        /// <param name="sqlParams"></param>
        private static void AddSqlParamsToSqlCommand(MySqlCommand commandObj, IDictionary<string, object> sqlParams)
        {
            foreach (var param in sqlParams)
            {
                commandObj.Parameters.AddWithValue(param.Key, param.Value);
            }
        }
    }
}
