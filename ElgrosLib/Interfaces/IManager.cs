using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    public interface IManager<T> where T : BaseEntity
    {
        /// <summary>
        /// Adds a new subcategory to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<bool> CreateAsync(T createEntity);

        /// <summary>
        /// Deletes a subcategory from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<bool> DeleteAsync(T deleteEntity);

        /// <summary>
        /// Gets all subcategories
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets a subcategory by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Updates a subcategory
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<bool> UpdateAsync(T updateEntity);
    }
}
