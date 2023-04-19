namespace ElgrosLib.DataModels
{
    public class User : BaseEntity
    {
        private string _username;
        private string _password;

        public string Username { get; set; }

        internal User(int id, string username, string password) : base(id)
        {
            _username = username;
            _password = password;
        }
    }
}
