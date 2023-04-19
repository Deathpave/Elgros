using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;

namespace ElgrosLib.Repositories
{
    internal class UserInformationRepository : IUserInformationRepository
    {
        private readonly IDatabase _database;

        public UserInformationRepository(IDatabase database)
        {
            _database = database;
        }

        public Task<bool> CreateAsync(UserInformation createEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(UserInformation deleteEntity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserInformation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserInformation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(UserInformation updateEntity)
        {
            throw new NotImplementedException();
        }
    }
}
