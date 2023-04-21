using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;

namespace ElgrosLib.Logs
{
    /// <summary>
    /// Object class for the FileLog Entity
    /// </summary>
    internal class FileLog : Log
    {
        private string _logLocation;

        public FileLog(int id, string message, DateTime date, MessageTypes messageType, string logLocation) : base(id, messageType, message, date)
        {
            _logLocation = logLocation;
        }

        /// <summary>
        /// Writes the file log
        /// </summary>
        public override void WriteLog()
        {
            File.AppendAllText(_logLocation, $"{base.TimeStamp.ToString("dd-MM-yyyy hh:mm")} - {base.MessageType.ToString()} - {base.Message}\n");
        }
    }
}
