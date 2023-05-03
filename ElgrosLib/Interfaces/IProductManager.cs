using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    /// <summary>
    /// Interface for ProductManager class, meant to transfer CRUD methods
    /// </summary>
    public interface IProductManager : IManager<Product>
    {
        public Product ConvertToProduct(string name, string description, double price, int quantity, string photoUrl, int categoryId, int subCategoryId, int id = 0);
    }
}