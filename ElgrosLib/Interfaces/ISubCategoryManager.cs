using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    public interface ISubCategoryManager : IManager<SubCategory>
    {
        public SubCategory ConvertToSubCategory(string name, int categoryId);
    }
}
