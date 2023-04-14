using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;

namespace ElgrosLib.Logs
{
    /// <summary>
    /// Object class for the DatabaseLog Entity
    /// </summary>
    public class DatabaseLog : BaseEntity, ILog
    {
        private readonly string _message;
        private readonly MessageTypes _messageType;
        private readonly DateTime _date;

        public string Message { get { return _message; } }
        public MessageTypes MessageType { get { return _messageType; } }
        public DateTime TimeStamp { get { return _date; } }

        public DatabaseLog(long id, MessageTypes messageType, string message, DateTime date) : base(id)
        {
            _message = message;
            _messageType = messageType;
            _date = date;
        }

        public void WriteLog()
        {
        }
    }
}