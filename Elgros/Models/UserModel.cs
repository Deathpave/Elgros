namespace Elgros.Models
{
    /// <summary>
    /// UserModel with needed data for views
    /// </summary>
    public class UserModel
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int accountnr { get; set; }
        public int reg { get; set; }
    }
}