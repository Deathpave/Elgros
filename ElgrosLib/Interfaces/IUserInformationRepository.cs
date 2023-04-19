using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    internal interface IUserInformationRepository : IRepository<UserInformation>
    {
        /// <summary>
        /// Adds a new userinformation to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> CreateAsync(UserInformation createEntity);

        /// <summary>
        /// Deletes a userinformation from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteAsync(UserInformation deleteEntity);

        /// <summary>
        /// Gets all userinformations
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<UserInformation>> GetAllAsync();

        /// <summary>
        /// Gets a userinformation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<UserInformation> GetByIdAsync(int id);

        /// <summary>
        /// Updates a userinformation
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateAsync(UserInformation updateEntity);
    }
}
