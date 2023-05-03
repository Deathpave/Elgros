using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElgrosLib.Interfaces
{
    /// <summary>
    /// Interface for Database class
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Executes a given Query
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="sqlParams"></param>
        /// <returns>DbDataReader</returns>
        Task<DbDataReader> ExecuteQueryAsync(DbCommand sqlCommand, IDictionary<string, object> sqlParams = null);
        /// <summary>
        /// Opens Database connection
        /// </summary>
        /// <returns>True or False</returns>
        Task<bool> OpenConnectionAsync();
        /// <summary>
        /// Clsoes Database Connection
        /// </summary>
        /// <returns>True or False</returns>
        Task<bool> CloseConnectionAsync();
    }
}
