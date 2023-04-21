using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Logs;
using ElgrosLib.Repositories;

namespace ElgrosLib.Managers
{
    public class LogManager : ILogManager
    {
        private static LogManager _logManager;
        private readonly LogRepository _logRepository;

        private LogManager(IDatabase database)
        {
            _logRepository = new LogRepository(database);
        }

        public static LogManager GetLogManager(IDatabase database)
        {
            if (_logManager != null)
            {
                return _logManager;
            }
            else
            {
                _logManager = new LogManager(database);
                return _logManager;
            }
        }

        public Task<Log> ConvertToLog(MessageTypes messageType, string message, LogTypes logType)
        {
            return Task.FromResult(LogFactory.CreateLog(logType, message, messageType));
        }

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

        public Task<bool> DeleteAsync(Log deleteEntity)
        {
            throw new Exception("Logs are only allowed to be created");
        }

        public Task<IEnumerable<Log>> GetAllAsync()
        {
            throw new Exception("Logs are only allowed to be created");
        }

        public Task<Log> GetByIdAsync(int id)
        {
            throw new Exception("Logs are only allowed to be created");
        }

        public void LogErrorLocally(Exception exception)
        {
            throw new Exception("Logs are only allowed to be created");
        }

        public Task<bool> UpdateAsync(Log updateEntity)
        {
            throw new Exception("Logs are only allowed to be created");
        }
    }
}
