using ElgrosLib.DataModels;

namespace Elgros.Models
{
    /// <summary>
    /// CartModel with needed cart data
    /// </summary>
    public class CartModel
    {
        public Product product { get; set; }

        public UserInformation userInformation { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}