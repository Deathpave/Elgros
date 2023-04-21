using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using ElgrosLib.Logs;
using ElgrosLib.Repositories;

namespace ElgrosLib.Managers
{
    public class LogManager : ILogManager
    {
        private readonly LogRepository _logRepository;

        public LogManager(IDatabase database)
        {
            _logRepository = new LogRepository(database);
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

        public Task<bool> UpdateAsync(Log updateEntity)
        {
            throw new Exception("Logs are only allowed to be created");
        }
    }
}
