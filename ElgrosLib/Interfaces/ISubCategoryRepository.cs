using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    internal interface ISubCategoryRepository
    {
        /// <summary>
        /// Adds a new category to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> CreateAsync(SubCategory createEntity);

        /// <summary>
        /// Deletes a category from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteAsync(SubCategory deleteEntity);

        /// <summary>
        /// Gets all categorys
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<SubCategory>> GetAllAsync();

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<SubCategory> GetByIdAsync(int id);

        /// <summary>
        /// Updates a category
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateAsync(SubCategory updateEntity);
    }
}
