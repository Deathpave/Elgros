using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ElgrosLib.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        // Database instance
        private readonly IDatabase _database;

        /// <summary>
        /// Constructor that sets the database
        /// </summary>
        /// <param name="database"></param>
        public CategoryRepository(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Creates a category entity in the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> CreateAsync(Category createEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spCreateCategory");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@name",createEntity.Name}
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
        /// Deletes a category entity in the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteAsync(Category deleteEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spDeleteCategory");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@categoryId",deleteEntity.Id}
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
        /// Gets all category entities from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            List<Category> categories = new List<Category>();

            // Create dbcommand
            DbCommand command = new SqlCommand("spGetAllCategories");
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
                    Category category = new Category(dataReader.GetInt32("id"), dataReader.GetString("name"));
                    categories.Add(category);
                }
                await _database.CloseConnectionAsync();
                return categories;
            }
        }

        /// <summary>
        /// Gets a specific category entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Category> GetByIdAsync(int id)
        {
            // Create dbcommand
            DbCommand command = new SqlCommand("spGetCategoryById");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@categoryId",id}
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
                Category category = null;
                while (dataReader.Read())
                {
                    category = new Category(dataReader.GetInt32("id"), dataReader.GetString("name"));
                }
                await _database.CloseConnectionAsync();
                return await Task.FromResult(category);
            }
        }

        /// <summary>
        /// Updates a category entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Category updateEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spUpdateCategory");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@name",updateEntity.Name}
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
