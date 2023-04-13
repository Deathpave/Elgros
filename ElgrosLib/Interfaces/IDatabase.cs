using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElgrosLib.Interfaces
{
    public interface IDatabase
    {
        Task<DbDataReader> ExecuteQueryAsync(DbCommand sqlCommand, IDictionary<string, object> sqlParams = null);
        Task<bool> OpenConnectionAsync();
        Task<bool> CloseConnectionAsync();
    }
}
