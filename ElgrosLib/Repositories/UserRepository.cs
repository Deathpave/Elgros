using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace ElgrosLib.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly IDatabase _database;

        public UserRepository(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Creates a user entity in the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns>true or false</returns>
        public async Task<bool> CreateAsync(User createEntity)
        {
            int affectedRows = 0;

            // Create dbcommand with parameters
            DbCommand command = new SqlCommand("spCreateUser");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@name",createEntity.Name},
                {"@lastName",createEntity.LastName},
                {"@email",createEntity.Email},
                {"@address",createEntity.Address},
                {"@zipcode",createEntity.Zipcode},
                {"@city",createEntity.City},
                {"@phone",createEntity.Phone},
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
        /// Deletes a user entity in the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteAsync(User deleteEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spDeleteUser");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@userId",deleteEntity.Id}
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
        /// Gets all user entities from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            List<User> users = new List<User>();

            // Create dbcommand
            DbCommand command = new SqlCommand("spGetAllUsers");
            command.CommandType = CommandType.StoredProcedure;

            // Get datareader with result from dbcommand
            using var dataReader = await _database.ExecuteQueryAsync(command);
            if (dataReader.HasRows == false)
            {
                await _database.CloseConnectionAsync();
                return users;
            }
            else
            {
                while (await dataReader.ReadAsync())
                {

                    User user = new User(dataReader.GetInt32("id"), dataReader.GetString("authenticationString"), dataReader.GetString("name"),
                        dataReader.GetString("lastName"), dataReader.GetString("email"), dataReader.GetString("address"), dataReader.GetString("zipcode"),
                        dataReader.GetString("city"), dataReader.GetString("phone"));
                    users.Add(user);
                }
                await _database.CloseConnectionAsync();
                return users;
            }
        }

        /// <summary>
        /// Gets a specific user entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<User> GetByIdAsync(int id)
        {
            // Create dbcommand
            DbCommand command = new SqlCommand("spGetUserById");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@userId",id}
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
                User user = null;
                while (dataReader.Read())
                {
                    user = new User(dataReader.GetInt32("id"), dataReader.GetString("authenticationString"), dataReader.GetString("name"),
                        dataReader.GetString("lastName"), dataReader.GetString("email"), dataReader.GetString("address"), dataReader.GetString("zipcode"),
                        dataReader.GetString("city"), dataReader.GetString("phone"));
                }
                await _database.CloseConnectionAsync();
                return await Task.FromResult(user);
            }
        }

        /// <summary>
        /// Updates a user entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateAsync(User updateEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spUpdateUser");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@name",updateEntity.Name},
                {"@lastName",updateEntity.LastName},
                {"@email",updateEntity.Email},
                {"@address",updateEntity.Address},
                {"@zipcode",updateEntity.Zipcode},
                {"@city",updateEntity.City},
                {"@phone",updateEntity.Phone},
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
