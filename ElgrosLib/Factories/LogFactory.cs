using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using ElgrosLib.Logs;

namespace ElgrosLib.Factories
{
    /// <summary>
    /// Factory that handles the creation of Log objects
    /// </summary>
    public static class LogFactory
    {
        private static string _errorLogLocation;

        /// <summary>
        /// Sets needed data for factory
        /// </summary>
        /// <param name="errorLogLocation"></param>
        public static void Initialize(string errorLogLocation)
        {
            _errorLogLocation = errorLogLocation;
        }

        /// <summary>
        /// Returns a log depending on log type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public static Log CreateLog(LogTypes type, string message, MessageTypes messageType)
        {
            ILog log = null;
            switch (type)
            {
                case LogTypes.Database:
                    log = new DatabaseLog(0, messageType, message, DateTime.Now);
                    break;
                case LogTypes.File:
                    log = new FileLog(0, message, DateTime.Now, messageType, _errorLogLocation);
                    break;
                case LogTypes.Console:
                    log = new ConsoleLog(0, messageType, message, DateTime.Now);
                    break;
            }
            return log;
        }
    }
}