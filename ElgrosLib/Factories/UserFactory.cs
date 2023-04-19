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
        public static User CreateUser(int id, string username, string password)
        {
            return new User(id, username, password);
        }
    }
}
