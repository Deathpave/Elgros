using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;
using ElgrosLib.Security;
using ElgrosLib.Logs;

namespace ElgrosLib.Managers
{
    /// <summary>
    /// Manager class for handling UserInformation objects
    /// </summary>
    public class UserInformationManager : IUserInformationManager
    {
        private readonly UserInformationRepository _repository;

        public UserInformationManager(IDatabase database)
        {
            _repository = new UserInformationRepository(database);
        }

        /// <summary>
        /// Converts variables into a UserInformation object
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="zipcode"></param>
        /// <param name="city"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public UserInformation ConvertToUserInformation(int userId, string name, string lastname, string email, string address, string zipcode, string city, string phone)
        {
            try
            {
                Encryption encryption = new Encryption();

                return UserInformationFactory.CreateUserInformation(userId, encryption.EncryptString(name, userId.ToString()),
                    encryption.EncryptString(lastname, userId.ToString()), encryption.EncryptString(email, userId.ToString()), encryption.EncryptString(address, userId.ToString()),
                    encryption.EncryptString(zipcode, userId.ToString()), encryption.EncryptString(city, userId.ToString()), encryption.EncryptString(phone, userId.ToString()));
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"UserInformationManager could not convert data to subcategory\n{e.Message}", LogTypes.Database).Result);
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
        /// Saves a UserInformation entity to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns>True or False</returns>
        public Task<bool> CreateAsync(UserInformation createEntity)
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
                    MessageTypes.Error, $"UserInformationManager could not create userinformation\n{e.Message}", LogTypes.Database).Result);
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
        /// Deletes a UserInformation entity from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns>True or False</returns>
        public Task<bool> DeleteAsync(UserInformation deleteEntity)
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
                    MessageTypes.Error, $"UserInformationManager could not delete userinformation\n{e.Message}", LogTypes.Database).Result);
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
        /// Gets all UserInformation entities from the database
        /// </summary>
        /// <returns>IEnumerable with all UserInformations</returns>
        public Task<IEnumerable<UserInformation>> GetAllAsync()
        {
            return null;
        }

        /// <summary>
        /// Gets a specific UserInformation entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<UserInformation> GetByIdAsync(int id)
        {
            try
            {
                Decryption decryption = new Decryption();
                UserInformation encryptedUserInformation = _repository.GetByIdAsync(id).Result;
                UserInformation userInformation = UserInformationFactory.CreateUserInformation(id, decryption.DecryptString(encryptedUserInformation.FirstName, id.ToString()),
                    decryption.DecryptString(encryptedUserInformation.LastName, id.ToString()), decryption.DecryptString(encryptedUserInformation.Email, id.ToString()),
                    decryption.DecryptString(encryptedUserInformation.Address, id.ToString()), decryption.DecryptString(encryptedUserInformation.Zipcode, id.ToString()),
                    decryption.DecryptString(encryptedUserInformation.City, id.ToString()), decryption.DecryptString(encryptedUserInformation.Phone, id.ToString()));
                return Task.FromResult(userInformation);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"UserInformationManager could not get userinformation by id\n{e.Message}", LogTypes.Database).Result);
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
        /// Updates a UserInformation entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns>True or False</returns>
        public Task<bool> UpdateAsync(UserInformation updateEntity)
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
                    MessageTypes.Error, $"UserInformationManager could not update userinformation\n{e.Message}", LogTypes.Database).Result);
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
        /// Logs error locally in case of missing database connection
        /// </summary>
        /// <param name="exception"></param>
        public void LogErrorLocally(Exception exception)
        {
            LogManager.GetLogManager(null).CreateAsync(
                   LogManager.GetLogManager(null).ConvertToLog(
                   MessageTypes.Error, $"UserInformationManager could not write log to database\n{exception.Message}", LogTypes.File).Result);
        }
    }
}