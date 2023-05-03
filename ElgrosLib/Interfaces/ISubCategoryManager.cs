using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    /// <summary>
    /// Interface for SubCategoryManager class, meant to trasnfer CRUD methods.
    /// </summary>
    public interface ISubCategoryManager : IManager<SubCategory>
    {
        public SubCategory ConvertToSubCategory(string name, int categoryId, int id = 0);
    }
}
