using ElgrosLib.DataModels;

namespace Elgros.Models
{
    public class CartModel
    {
        public Product product { get; set; }

        public UserInformation userInformation { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}