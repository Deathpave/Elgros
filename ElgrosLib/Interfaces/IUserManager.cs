using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    public interface IUserManager : ICRUD<User>
    {
        public Task<int> CheckLogin(string username, string password);

    }
}
