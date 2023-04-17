﻿using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    internal interface ICategoryRepository
    {
        /// <summary>
        /// Adds a new category to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> CreateAsync(Category createEntity);

        /// <summary>
        /// Deletes a category from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteAsync(Category deleteEntity);

        /// <summary>
        /// Gets all categorys
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<Category>> GetAllAsync();

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Category> GetByIdAsync(int id);

        /// <summary>
        /// Updates a category
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateAsync(Category updateEntity);
    }
}