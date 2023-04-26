using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    public interface IUserManager : IManager<User>
    {
        public Task<int> CheckLogin(string username, string password);
        public User ConvertToUser(string username, string password, int id = 0);
        public Task<User> GetByNameAsync(string name);
        public Task<string> CreateUserToken(User user);
        public Task<int> GetUserIdFromUserToken(string token);
    }
}
