using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    /// <summary>
    /// Interface for UserInformationManager class, meant to transfer CRUD methods.
    /// </summary>
    public interface IUserInformationManager : IManager<UserInformation>
    {
        public UserInformation ConvertToUserInformation(int userId, string name, string lastname, string email, string address, string zipcode, string city, string phone);
    }
}
