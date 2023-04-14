using ElgrosLib.Interfaces;

namespace ElgrosLib.Logs
{
    /// <summary>
    /// Object class for the ConsoleLog entity.
    /// </summary>
    internal class ConsoleLog : ILog
    {
        private string _message;
        private MessageTypes _messageType;
        private DateTime _date;

        public ConsoleLog(string message, DateTime date, MessageTypes messageType)
        {
            _message = message;
            _date = date;
            _messageType = messageType;
        }

        /// <summary>
        /// Prints log to console
        /// </summary>
        public void WriteLog()
        {
            Console.WriteLine($"{_date.ToString("dd-MM-yyyy hh:mm")} - {_messageType.ToString()} - {_message}");
        }
    }
}