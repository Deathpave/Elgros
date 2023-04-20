using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;
using ElgrosLib.Security;

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
            Encryption encryption = new Encryption();

            return UserInformationFactory.CreateUserInformation(userId, encryption.EncryptString(name, userId.ToString()),
                encryption.EncryptString(lastname, userId.ToString()), encryption.EncryptString(email, userId.ToString()), encryption.EncryptString(address, userId.ToString()),
                encryption.EncryptString(zipcode, userId.ToString()), encryption.EncryptString(city, userId.ToString()), encryption.EncryptString(phone, userId.ToString()));
        }

        public Task<bool> CreateAsync(UserInformation createEntity)
        {
            return _repository.CreateAsync(createEntity);
        }

        public Task<bool> DeleteAsync(UserInformation deleteEntity)
        {
            return _repository.DeleteAsync(deleteEntity);
        }

        public Task<IEnumerable<UserInformation>> GetAllAsync()
        {
            return null;
        }

        public Task<UserInformation> GetByIdAsync(int id)
        {
            Decryption decryption = new Decryption();
            UserInformation encryptedUserInformation = _repository.GetByIdAsync(id).Result;
            UserInformation userInformation = UserInformationFactory.CreateUserInformation(id, decryption.DecryptString(encryptedUserInformation.Name, id.ToString()),
                decryption.DecryptString(encryptedUserInformation.LastName, id.ToString()), decryption.DecryptString(encryptedUserInformation.Email, id.ToString()),
                decryption.DecryptString(encryptedUserInformation.Address, id.ToString()), decryption.DecryptString(encryptedUserInformation.Zipcode, id.ToString()),
                decryption.DecryptString(encryptedUserInformation.City, id.ToString()), decryption.DecryptString(encryptedUserInformation.Phone, id.ToString()));
            return Task.FromResult(userInformation);
        }

        public Task<bool> UpdateAsync(UserInformation updateEntity)
        {
            return _repository.UpdateAsync(updateEntity);
        }
    }
}