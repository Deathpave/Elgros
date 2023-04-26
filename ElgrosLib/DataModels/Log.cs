using ElgrosLib.Interfaces;
using ElgrosLib.Logs;

namespace ElgrosLib.DataModels
{
    public class Log : BaseEntity, ILog
    {
        private readonly string _message;
        private readonly MessageTypes _messageType;
        private readonly DateTime _date;
        private readonly LogTypes _logType;

        public string Message { get { return _message; } }
        public MessageTypes MessageType { get { return _messageType; } }
        public DateTime TimeStamp { get { return _date; } }

        public Log(int id, MessageTypes messageType, string message, DateTime date) : base(id)
        {
            _message = message;
            _messageType = messageType;
            _date = date;
        }

        public virtual void WriteLog()
        {
        }
    }
}
