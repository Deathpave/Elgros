using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Logs;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

namespace ElgrosLib.Adapters
{
    internal abstract class Database : IDatabase
    {
        private readonly IConfiguration _configuration;
        private readonly string _databaseName;
        private IDbConnection _connection = null;
        public IConfiguration Configuration { get { return _configuration; } }
        public string DatabaseName { get { return _databaseName; } }

        public IDbConnection Connection
        {
            get { return _connection; }
            set
            {
                if (_connection == null)
                {
                    _connection = value;
                }
            }
        }

        public Database(IConfiguration configuration, string databaseName)
        {
            _configuration = configuration;
            _databaseName = databaseName;
        }

        /// <summary>
        /// Default close connection method (not in use when overriding from other classes)
        /// </summary>
        /// <returns>True or False</returns>
        public virtual Task<bool> CloseConnectionAsync()
        {
            try
            {
                _connection.Close();
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                LogFactory.CreateLog(LogTypes.Console, "Database was unable to close connection", MessageTypes.Error).WriteLog();
                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// Default open connection method (not in use when overriding from other classes)
        /// </summary>
        /// <returns>True or False</returns>
        public virtual Task<bool> OpenConnectionAsync()
        {
            try
            {
                _connection.Open();
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                LogFactory.CreateLog(LogTypes.Console, "Database had a invalid connection", MessageTypes.Error).WriteLog();
                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// Default execute sql command (not in use when overriding from other classes)
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="sqlParams"></param>
        /// <returns>DbDataReader</returns>
        public virtual Task<DbDataReader> ExecuteQueryAsync(DbCommand sqlCommand, IDictionary<string, object> sqlParams = null)
        {
            LogFactory.CreateLog(LogTypes.Console, "Tried to execute sql command via abstract database class", MessageTypes.Error).WriteLog();
            return Task.FromResult<DbDataReader>(null);
        }
    }
}