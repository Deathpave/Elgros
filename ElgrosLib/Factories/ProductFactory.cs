using ElgrosLib.DataModels;

namespace ElgrosLib.Factories
{

    /// <summary>
    /// Factory that handles the creation of product objects
    /// </summary>
    public static class ProductFactory
    {
        /// <summary>
        /// Create product instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Product CreateProduct(int id, string name, string description, double price, double quantity, string photoUrl, int categoryId, int subCategoryId)
        {
            return new Product(id, name, description, price, quantity, photoUrl, categoryId, subCategoryId);
        }
    }
}
