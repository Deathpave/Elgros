using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;
using ElgrosLib.Security;
using ElgrosLib.Logs;

namespace ElgrosLib.Managers
{
    public class UserInformationManager : IUserInformationManager
    {
        private readonly UserInformationRepository _repository;

        public UserInformationManager(IDatabase database)
        {
            _repository = new UserInformationRepository(database);
        }

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

        public Task<IEnumerable<UserInformation>> GetAllAsync()
        {
            return null;
        }

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

        public void LogErrorLocally(Exception exception)
        {
            LogManager.GetLogManager(null).CreateAsync(
                   LogManager.GetLogManager(null).ConvertToLog(
                   MessageTypes.Error, $"UserInformationManager could not write log to database\n{exception.Message}", LogTypes.File).Result);
        }
    }
}