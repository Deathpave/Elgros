using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ElgrosLib.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        // Database instance
        private readonly IDatabase _database;

        /// <summary>
        /// Constructor that sets the database
        /// </summary>
        /// <param name="database"></param>
        public ProductRepository(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Creates a product entity in the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns>true or false</returns>
        public async Task<bool> CreateAsync(Product createEntity)
        {
            int affectedRows = 0;

            // Create dbcommand with parameters
            DbCommand command = new SqlCommand("spCreateProduct");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@name", createEntity.Name},
                {"@description",createEntity.Description},
                {"@price",createEntity.Price},
                {"@quantity",createEntity.Quantity},
                {"@photoUrl",createEntity.PhotoUrl},
                {"@categoryId",createEntity.CategoryId},
                {"@subCategoryId",createEntity.SubCategoryId}
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

        /// <summary>
        /// Deletes a product entity in the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteAsync(Product deleteEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spDeleteProduct");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@id",deleteEntity.Id}
            };

            // Get datareader with result from dbcommand
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
        /// Gets all product entities from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            List<Product> products = new List<Product>();

            // Create dbcommand
            DbCommand command = new SqlCommand("spGetAllProducts");
            command.CommandType = CommandType.StoredProcedure;

            // Get datareader with result from dbcommand
            using var dataReader = await _database.ExecuteQueryAsync(command);
            if (dataReader.HasRows == false) // Make it return error message to frontend
            {
                await _database.CloseConnectionAsync();
                return products;
            }
            else
            {
                while (await dataReader.ReadAsync())
                {
                    Product product = ProductFactory.CreateProduct(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("description"), dataReader.GetDouble("price"), dataReader.GetDouble("quantity"),
                    dataReader.GetString("photoUrl"), dataReader.GetInt32("categoryId"), dataReader.GetInt32("subCategoryId"));
                    products.Add(product);
                }
                await _database.CloseConnectionAsync();
                return products;
            }
        }

        /// <summary>
        /// Gets a specific product entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Product> GetByIdAsync(int id)
        {
            // Create dbcommand
            DbCommand command = new SqlCommand("spGetProductById");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@id",id}
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
                Product product = null;
                while (dataReader.Read())
                {
                    product = ProductFactory.CreateProduct(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("description"), dataReader.GetDouble("price"), dataReader.GetDouble("quantity"),
                       dataReader.GetString("photoUrl"), dataReader.GetInt32("categoryId"), dataReader.GetInt32("subCategoryId"));
                }
                await _database.CloseConnectionAsync();
                return await Task.FromResult(product);
            }
        }

        /// <summary>
        /// Updates a product entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateAsync(Product updateEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spUpdateProduct");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@name", updateEntity.Name},
                {"@description",updateEntity.Description},
                {"@price",updateEntity.Price},
                {"@quantity",updateEntity.Quantity},
                {"@photoUrl",updateEntity.PhotoUrl},
                {"@categoryId",updateEntity.CategoryId},
                {"@subCategoryId",updateEntity.SubCategoryId}
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
