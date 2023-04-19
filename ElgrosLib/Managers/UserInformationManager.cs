using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;
using Org.BouncyCastle.Tls;

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
            return UserInformationFactory.CreateUserInformation(userId, name, lastname, email, address, zipcode, city, phone);
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
            return _repository.GetAllAsync();
        }

        public Task<UserInformation> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(UserInformation updateEntity)
        {
            return _repository.UpdateAsync(updateEntity);
        }
    }
}