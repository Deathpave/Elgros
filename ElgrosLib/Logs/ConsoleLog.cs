using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;

namespace ElgrosLib.Logs
{
    /// <summary>
    /// Object class for the ConsoleLog entity.
    /// </summary>
    internal class ConsoleLog : Log
    {
        public ConsoleLog(int id, MessageTypes messageType, string message, DateTime date) : base(id, messageType, message, date)
        {
        }

        /// <summary>
        /// Prints log to console
        /// </summary>
        public override void WriteLog()
        {
            Console.WriteLine($"{base.TimeStamp.ToString("dd-MM-yyyy hh:mm")} - {base.MessageType.ToString()} - {base.Message}");
        }
    }
}