using ElgrosLib.DataModels;

namespace ElgrosLib.Factories
{
    /// <summary>
    /// Factory that handles the creation of user objects
    /// </summary>
    public static class UserFactory
    {
        /// <summary>
        /// Create user instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static User CreateUser(string authenticationString, string name, string lastName, string email, string address, string zipcode, string city, string phone)
        {
            return new User(0, authenticationString, name, lastName, email, address, zipcode, city, phone);
        }
    }
}
