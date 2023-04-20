using ElgrosLib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElgrosLib.Interfaces
{
    public interface ISubCategoryManager
    {
        /// <summary>
        /// Adds a new subcategory to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> CreateAsync(SubCategory createEntity);

        /// <summary>
        /// Deletes a subcategory from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteAsync(SubCategory deleteEntity);

        /// <summary>
        /// Gets all subcategories
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<SubCategory>> GetAllAsync();

        /// <summary>
        /// Gets a subcategory by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<SubCategory> GetByIdAsync(int id);

        /// <summary>
        /// Updates a subcategory
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateAsync(SubCategory updateEntity);
    }
}
