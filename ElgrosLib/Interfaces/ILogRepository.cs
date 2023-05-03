using ElgrosLib.Logs;

namespace ElgrosLib.Interfaces
{
    /// <summary>
    /// Interface for LogRepository class, meant to trasnfer CRUD methods.
    /// </summary>
    internal interface ILogRepository : IRepository<DatabaseLog>
    {
    }
}
