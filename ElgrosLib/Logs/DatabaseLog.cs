using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;

namespace ElgrosLib.Logs
{
    /// <summary>
    /// Object class for the DatabaseLog Entity
    /// </summary>
    public class DatabaseLog : Log
    {
        public DatabaseLog(int id, MessageTypes messageType, string message, DateTime date) : base(id, messageType, message, date)
        {
        }
    }
}