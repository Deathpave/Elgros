using ElgrosLib.DataModels;

namespace Elgros.Models
{
    public class ProductModel
    {
        public List<Product> Products { get; set; }

        ProductModel(List<Product> products)
        {
            Products = products;    
        }
    }
}
