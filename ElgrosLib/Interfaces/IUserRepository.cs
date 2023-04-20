using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    internal interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Adds a new user to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> CreateAsync(User createEntity);

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteAsync(User deleteEntity);

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<User>> GetAllAsync();

        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<User> GetByIdAsync(int id);

        /// <summary>
        /// Gets a user by name
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<User> GetByNameAsync(string name);

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateAsync(User updateEntity);
    }
}
