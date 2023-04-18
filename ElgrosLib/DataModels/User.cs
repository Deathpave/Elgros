namespace ElgrosLib.DataModels
{
    public class User : BaseEntity
    {
        private string _authenticationString;
        private string _name;
        private string _lastName;
        private string _email;
        private string _address;
        private string _zipcode;
        private string _city;
        private string _phone;

        public string AuthenticationString { get { return _authenticationString; } }
        public string Name { get { return _name; } }
        public string LastName { get { return _lastName; } }
        public string Email { get { return _email; } }
        public string Address { get { return _address; } }
        public string Zipcode { get { return _zipcode; } }
        public string City { get { return _city; } }
        public string Phone { get { return _phone; } }

        internal User(int id, string authenticationString, string name, string lastName, string email, string address, string zipcode, string city, string phone) : base(id)
        {
            _authenticationString = authenticationString;
            _name = name;
            _lastName = lastName;
            _email = email;
            _address = address;
            _zipcode = zipcode;
            _city = city;
            _phone = phone;
        }
    }
}
