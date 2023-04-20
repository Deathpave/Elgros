using ElgrosLib.DataModels;

namespace ElgrosLib.Factories
{
    /// <summary>
    /// Factory that handles the creation of SubCategory objects
    /// </summary>
    public static class SubCategoryFactory
    {
        /// <summary>
        /// Create Subcategory instance
        /// </summary>
        /// <param name="name"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static SubCategory CreateSubCategory(int id, string name, int categoryId)
        {
            return new SubCategory(id, name, categoryId);
        }
    }
}
