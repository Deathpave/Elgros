using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Logs;
using ElgrosLib.Repositories;
using ElgrosLib.Security;

namespace ElgrosLib.Managers
{
    public class UserManager : IUserManager
    {
        private readonly UserRepository _repository;

        public UserManager(IDatabase database)
        {
            _repository = new UserRepository(database);
        }

        public async Task<int> CheckLogin(string username, string password)
        {
            Encryption encryption = new Encryption();
            User user = _repository.GetByNameAsync(encryption.EncryptString(username, username)).Result;
            if (user != null)
            {
                if (user.Password == new Hashing().Sha256Hash(encryption.EncryptString(password, password)))
                {
                    return await Task.FromResult(user.Id);
                }
                else
                {
                    LogFactory.CreateLog(LogTypes.Database, $"Failed login with username {username}", MessageTypes.Error);
                    return await Task.FromResult(-1);
                }
            }
            else
            {
                return await Task.FromResult(-1);
            }
        }

        public User ConvertToUser(string username, string password)
        {
            try
            {
                Encryption encryption = new Encryption();
                User user = UserFactory.CreateUser(0, encryption.EncryptString(username, username), new Hashing().Sha256Hash(encryption.EncryptString(password, password)));
                return user;
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"UserManager could not convert data to User\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"UserManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }

        public Task<bool> CreateAsync(User createEntity)
        {
            try
            {
                return _repository.CreateAsync(createEntity);
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"UserManager could not create User\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"UserManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }

        public Task<bool> DeleteAsync(User deleteEntity)
        {
            try
            {
                return _repository.DeleteAsync(deleteEntity);
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"UserManager could not delete User\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"UserManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return null;
        }

        public Task<User> GetByIdAsync(int id)
        {
            return null;
        }

        public Task<bool> UpdateAsync(User updateEntity)
        {
            try
            {
                return _repository.UpdateAsync(updateEntity);
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"UserManager could not update User\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"UserManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }
    }
}