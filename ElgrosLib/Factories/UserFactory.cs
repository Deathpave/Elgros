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
        public static User CreateUser(string username, string password)
        {
            return new User(0, username, password);
        }
    }
}
