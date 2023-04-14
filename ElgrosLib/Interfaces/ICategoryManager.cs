using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    public interface ICategoryManager
    {
        /// <summary>
        /// Adds a new category to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> CreateAsync(Product createEntity);

        /// <summary>
        /// Deletes a category from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteAsync(Product deleteEntity);

        /// <summary>
        /// Gets all categorys
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Product> GetByIdAsync(long id);

        /// <summary>
        /// Updates a category
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateAsync(Product updateEntity);
    }
}
