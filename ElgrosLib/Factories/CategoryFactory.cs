using ElgrosLib.DataModels;

namespace ElgrosLib.Factories
{
    /// <summary>
    /// Factory that handles the creation of category objects
    /// </summary>
    internal static class CategoryFactory
    {
        /// <summary>
        /// Create category instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static Category CreateCategory(int id, string name)
        {
            return new Category(id, name);
        }
    }
}
