using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;

namespace ElgrosLib.Managers
{
    public class UserManager : IUserManager
    {
        private readonly UserRepository _repository;

        public UserManager(IDatabase database)
        {
            _repository = new UserRepository(database);
        }

        public User ConvertToUser(string username, string password)
        {
            return UserFactory.CreateUser(username, password);
        }

        public Task<bool> CreateAsync(User createEntity)
        {
            return _repository.CreateAsync(createEntity);
        }

        public Task<bool> DeleteAsync(User deleteEntity)
        {
            return _repository.DeleteAsync(deleteEntity);
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<User> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(User updateEntity)
        {
            return _repository.UpdateAsync(updateEntity);
        }
    }
}