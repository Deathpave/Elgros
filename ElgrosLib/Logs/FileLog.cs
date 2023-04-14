using ElgrosLib.Interfaces;

namespace ElgrosLib.Logs
{
    /// <summary>
    /// Object class for the FileLog Entity
    /// </summary>
    internal class FileLog : ILog
    {
        private string _logLocation;
        private string _message;
        private DateTime _date;
        private MessageTypes _messageType;

        public FileLog(string message, DateTime date, MessageTypes messageType, string logLocation)
        {
            _logLocation = logLocation;
            _message = message;
            _date = date;
            _messageType = messageType;
        }

        /// <summary>
        /// Writes the file log
        /// </summary>
        public void WriteLog()
        {
            File.AppendAllText(_logLocation, $"{_date.ToString("dd-MM-yyyy hh:mm")} - {_messageType.ToString()} - {_message}\n");
        }
    }
}
