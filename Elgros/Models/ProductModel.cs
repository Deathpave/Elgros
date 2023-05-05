using ElgrosLib.DataModels;

namespace Elgros.Models
{
    /// <summary>
    /// ProductModel with needed product data for views
    /// </summary>
    public class ProductModel
    {
        public IEnumerable<Product> Products { get; set; }
        public ProductModel(IEnumerable<Product> products)
        {
            Products = products;    
        }
    }
}
