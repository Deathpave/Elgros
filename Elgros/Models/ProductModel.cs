using ElgrosLib.DataModels;

namespace Elgros.Models
{
    public class ProductModel
    {
        public IEnumerable<Product> Products { get; set; }
        public ProductModel(IEnumerable<Product> products)
        {
            Products = products;    
        }
    }
}
