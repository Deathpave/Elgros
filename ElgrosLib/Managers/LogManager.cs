using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Logs;
using ElgrosLib.Repositories;

namespace ElgrosLib.Managers
{
    /// <summary>
    /// Manager class for handling Log objects
    /// </summary>
    public class LogManager : ILogManager
    {
        private static LogManager _logManager;
        private readonly LogRepository _logRepository;

        private LogManager(IDatabase database)
        {
            _logRepository = new LogRepository(database);
        }

        public static LogManager GetLogManager(IDatabase database, string errorLogLocation = "")
        {
            if (_logManager != null)
            {
                return _logManager;
            }
            else
            {
                _logManager = new LogManager(database);
                LogFactory.Initialize(errorLogLocation);
                return _logManager;
            }
        }

        /// <summary>
        /// Converts variables into a Log object
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        /// <param name="logType"></param>
        /// <returns>Log</returns>
        public Task<Log> ConvertToLog(MessageTypes messageType, string message, LogTypes logType)
        {
            return Task.FromResult(LogFactory.CreateLog(logType, message, messageType));
        }

        /// <summary>
        /// Saves a Log entity in the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns>True or False</returns>
        public Task<bool> CreateAsync(Log createEntity)
        {
            switch (createEntity)
            {
                case DatabaseLog:
                    _logRepository.CreateAsync((DatabaseLog)createEntity);
                    break;
                case FileLog:
                    createEntity.WriteLog();
                    break;
                case ConsoleLog:
                    createEntity.WriteLog();
                    break;
            }
            try
            {
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// Deletes a Log entity from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns>True or False</returns>
        /// <exception cref="Exception"></exception>
        public Task<bool> DeleteAsync(Log deleteEntity)
        {
            throw new Exception("Logs are only allowed to be created");
        }

        /// <summary>
        /// Gets all Log entities from the database
        /// </summary>
        /// <returns>IEnumerable with all Logs</returns>
        /// <exception cref="Exception"></exception>
        public Task<IEnumerable<Log>> GetAllAsync()
        {
            throw new Exception("Logs are only allowed to be created");
        }
        
        /// <summary>
        /// Gets a specific Log entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Log</returns>
        /// <exception cref="Exception"></exception>
        public Task<Log> GetByIdAsync(int id)
        {
            throw new Exception("Logs are only allowed to be created");
        }

        /// <summary>
        /// Logs an error locally in case of missing database connection
        /// </summary>
        /// <param name="exception"></param>
        /// <exception cref="Exception"></exception>
        public void LogErrorLocally(Exception exception)
        {
            throw new Exception("Logs are only allowed to be created");
        }

        /// <summary>
        /// Updates a Log entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns>True or False</returns>
        /// <exception cref="Exception"></exception>
        public Task<bool> UpdateAsync(Log updateEntity)
        {
            throw new Exception("Logs are only allowed to be created");
        }
    }
}
