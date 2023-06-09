﻿using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ElgrosLib.Repositories
{
    /// <summary>
    /// Repository class for handling database calls for SubCategory objects
    /// </summary>
    internal class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Constructor that sets the database
        /// </summary>
        /// <param name="database"></param>
        internal SubCategoryRepository(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Creates a subcategory entity in the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> CreateAsync(SubCategory createEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spCreateSubCategory");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@subCategoryId",createEntity.Id},
                {"@newName",createEntity.Name},
                {"@newCategoryId",createEntity.CategoryId}
            };

            // Get datareader with result from dbcommand
            using var dataReader = await _database.ExecuteQueryAsync(command, parameters);
            dataReader.Read();
            affectedRows = dataReader.RecordsAffected;
            await _database.CloseConnectionAsync();

            if (affectedRows > 0)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        /// <summary>
        /// Deletes a subcategory entity in the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteAsync(SubCategory deleteEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spDeleteSubCategory");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@subCategoryId",deleteEntity.Id}
            };

            // Get datreader with result from dbcommand
            using var dataReader = await _database.ExecuteQueryAsync(command, parameters);
            dataReader.Read();
            affectedRows = dataReader.RecordsAffected;

            if (affectedRows > 0)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        /// <summary>
        /// Gets all subcategory entities from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            List<SubCategory> categories = new List<SubCategory>();

            // Create dbcommand
            DbCommand command = new SqlCommand("spGetAllSubCategories");
            command.CommandType = CommandType.StoredProcedure;

            // Get datareader with result from dbcommand
            using var dataReader = await _database.ExecuteQueryAsync(command);
            if (dataReader.HasRows == false)
            {
                await _database.CloseConnectionAsync();
                return categories;
            }
            else
            {
                while (await dataReader.ReadAsync())
                {
                    SubCategory category = SubCategoryFactory.CreateSubCategory((int?)dataReader.GetInt32("id") ?? 0, dataReader.GetString("name") ?? "",
                    (int?)dataReader.GetInt32("categoryId") ?? 0);
                    categories.Add(category);
                }
                await _database.CloseConnectionAsync();
                return categories;
            }
        }

        /// <summary>
        /// Gets a specific subcategory entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<SubCategory> GetByIdAsync(int id)
        {
            // Create dbcommand
            DbCommand command = new SqlCommand("spGetSubCategoryById");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@subCategoryId",id}
            };

            // Get datareader with result from dbcommand
            using var dataReader = await _database.ExecuteQueryAsync(command, parameters);
            if (dataReader.HasRows == false)
            {
                await _database.CloseConnectionAsync();
                return null;
            }
            else
            {
                SubCategory category = null;
                while (dataReader.Read())
                {
                    category = SubCategoryFactory.CreateSubCategory((int?)dataReader.GetInt32("id") ?? 0, dataReader.GetString("name") ?? "",
                    (int?)dataReader.GetInt32("categoryId") ?? 0);
                }
                await _database.CloseConnectionAsync();
                return await Task.FromResult(category);
            }
        }

        /// <summary>
        /// Updates a subcategory entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateAsync(SubCategory updateEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spUpdateSubCategory");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@subCategoryId",updateEntity.Id},
                {"@newName",updateEntity.Name},
                {"@newCategoryId",updateEntity.CategoryId}
            };

            // Get datareader with result from the dbcommand
            using var dataReader = await _database.ExecuteQueryAsync(command, parameters);
            dataReader.Read();
            affectedRows = dataReader.RecordsAffected;
            await _database.CloseConnectionAsync();

            if (affectedRows > 0)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }
    }
}
