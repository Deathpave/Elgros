﻿using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    public interface IProductManager
    {
        /// <summary>
        /// Adds a new product to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> CreateAsync(Product createEntity);

        /// <summary>
        /// Deletes a product from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteAsync(Product deleteEntity);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// Gets a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Product> GetByIdAsync(int id);

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateAsync(Product updateEntity);
    }
}