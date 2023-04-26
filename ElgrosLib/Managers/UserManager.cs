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
                    await LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"Failed login with username {username}", LogTypes.Database).Result);
                    return await Task.FromResult(-1);
                }
            }
            else
            {
                return await Task.FromResult(-1);
            }
        }

        public User ConvertToUser(string username, string password, int id = 0)
        {
            try
            {
                Encryption encryption = new Encryption();
                User user = UserFactory.CreateUser(id, encryption.EncryptString(username, username), new Hashing().Sha256Hash(encryption.EncryptString(password, password)));
                return user;
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"UserManager could not convert data to User\n{e.Message}", LogTypes.Database).Result);
                    return null;
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
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
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"UserManager could not create User\n{e.Message}", LogTypes.Database).Result);
                    return null;
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
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
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"UserManager could not delete User\n{e.Message}", LogTypes.Database).Result);
                    return null;
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
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
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"UserManager could not update User\n{e.Message}", LogTypes.Database).Result);
                    return null;
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
                    return null;
                }
            }
        }

        public void LogErrorLocally(Exception exception)
        {
            LogManager.GetLogManager(null).CreateAsync(
                   LogManager.GetLogManager(null).ConvertToLog(
                   MessageTypes.Error, $"UserManager could not write log to database\n{exception.Message}", LogTypes.File).Result);
        }

        public async Task<User> GetByNameAsync(string name)
        {
            try
            {
                return await _repository.GetByNameAsync(name);
            }
            catch (Exception e)
            {
                try
                {
                    await LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"UserManager could not convert get user by name\n{e.Message}", LogTypes.Database).Result);
                    return null;
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
                    return null;
                }
            }
        }

        public async Task<string> CreateUserToken(int id)
        {
            return new Encryption().EncryptString(id.ToString(), "Id");
        }

        public async Task<int> GetUserIdFromUserToken(string token)
        {
            return int.Parse(new Decryption().DecryptString(token, "Id"));
        }
    }
}