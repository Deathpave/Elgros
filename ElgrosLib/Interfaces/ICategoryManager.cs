using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    /// <summary>
    /// Interface for CategoryManager class, meant to transfer CRUD methods.
    /// </summary>
    public interface ICategoryManager : IManager<Category>
    {
        public Category ConvertToCategory(string name, int id = 0);
    }
}
