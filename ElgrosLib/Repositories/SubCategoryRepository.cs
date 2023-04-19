using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ElgrosLib.Repositories
{
    internal class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Constructor that sets the database
        /// </summary>
        /// <param name="database"></param>
        public SubCategoryRepository(IDatabase database)
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
                {"@name",createEntity.Name},
                {"@categoryId",createEntity.CategoryId}
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
                    SubCategory category = new SubCategory(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetInt32("categoryId"));
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
            DbCommand command = new SqlCommand("spGetCategoryById");
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
                    category = new SubCategory(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetInt32("categoryId"));
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
            DbCommand command = new SqlCommand("spUpdateCategory");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@name",updateEntity.Name},
                {"@categoryId",updateEntity.CategoryId}
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
