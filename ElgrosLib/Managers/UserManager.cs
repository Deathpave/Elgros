using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Logs;
using ElgrosLib.Repositories;
using ElgrosLib.Security;

namespace ElgrosLib.Managers
{
    /// <summary>
    /// Manager class for handling User objects
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly UserRepository _repository;

        public UserManager(IDatabase database)
        {
            _repository = new UserRepository(database);
        }

        /// <summary>
        /// Checks a login attempt
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>user id</returns>
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

        /// <summary>
        /// Converts variables into a User object
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Saves a User entity to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns>True or False</returns>
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

        /// <summary>
        /// Deletes a User entity from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns>True or False</returns>
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

        /// <summary>
        /// Gets all user entities from the database
        /// </summary>
        /// <returns>IEnumerable with all Users</returns>
        public Task<IEnumerable<User>> GetAllAsync()
        {
            return null;
        }

        /// <summary>
        /// Gets a specific User entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        public Task<User> GetByIdAsync(int id)
        {
            return null;
        }

        /// <summary>
        /// Updates a User entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Logs an error locally in case of missing database connection
        /// </summary>
        /// <param name="exception"></param>
        public void LogErrorLocally(Exception exception)
        {
            LogManager.GetLogManager(null).CreateAsync(
                   LogManager.GetLogManager(null).ConvertToLog(
                   MessageTypes.Error, $"UserManager could not write log to database\n{exception.Message}", LogTypes.File).Result);
        }

        /// <summary>
        /// Gets a specific User entity from the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns>User</returns>
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

        /// <summary>
        /// Creates a token for User sessions
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Token String</returns>
        public async Task<string> CreateUserToken(int id)
        {
            return new Encryption().EncryptString(id.ToString(), "Id");
        }

        /// <summary>
        /// Gets the ID of a User from their UserToken
        /// </summary>
        /// <param name="token"></param>
        /// <returns>User Id</returns>
        public async Task<int> GetUserIdFromUserToken(string token)
        {
            return int.Parse(new Decryption().DecryptString(token, "Id"));
        }
    }
}