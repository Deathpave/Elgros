namespace ElgrosLib.DataModels
{
    public class UserInformation : BaseEntity
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _address;
        private string _zipcode;
        private string _city;
        private string _phone;

        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
        public string Email { get { return _email; } }
        public string Address { get { return _address; } }
        public string Zipcode { get { return _zipcode; } }
        public string City { get { return _city; } }
        public string Phone { get { return _phone; } }

        public UserInformation(int id, string name, string lastname, string email, string address, string zipcode, string city, string phone) : base(id)
        {
            _firstName = name;
            _lastName = lastname;
            _email = email;
            _address = address;
            _zipcode = zipcode;
            _city = city;
            _phone = phone;
        }
    }
}
