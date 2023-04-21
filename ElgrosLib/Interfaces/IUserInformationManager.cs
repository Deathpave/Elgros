using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    public interface IUserInformationManager : IManager<UserInformation>
    {
        public UserInformation ConvertToUserInformation(int userId, string name, string lastname, string email, string address, string zipcode, string city, string phone);
    }
}
