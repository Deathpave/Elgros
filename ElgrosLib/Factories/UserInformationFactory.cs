using ElgrosLib.DataModels;

namespace ElgrosLib.Factories
{
    /// <summary>
    /// Factory that handles the creation of userinformation objects
    /// </summary>
    internal static class UserInformationFactory
    {
        /// <summary>
        /// Create userinformation instance
        /// </summary>
        /// <param name="firstname"></param>
        /// <returns></returns>
        internal static UserInformation CreateUserInformation(int id, string firstname, string lastname, string email, string address, string zipcode, string city, string phone)
        {
            return new UserInformation(id, firstname, lastname, email, address, zipcode, city, phone);
        }
    }
}
