using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    public interface IUserManager : IManager<User>
    {
        public Task<int> CheckLogin(string username, string password);
        public User ConvertToUser(string username, string password);
        public Task<User> GetByNameAsync(string name);
    }
}
