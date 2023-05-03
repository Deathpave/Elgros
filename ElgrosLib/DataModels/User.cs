namespace ElgrosLib.DataModels
{
    /// <summary>
    /// POGO class for a User
    /// </summary>
    public class User : BaseEntity
    {
        private string _username;
        private string _password;

        public string Username { get { return _username; } }
        public string Password { get { return _password; } }

        internal User(int id, string username, string password) : base(id)
        {
            _username = username;
            _password = password;
        }
    }
}
