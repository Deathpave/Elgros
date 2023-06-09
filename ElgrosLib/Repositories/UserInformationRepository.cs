﻿using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using ElgrosLib.Factories;

namespace ElgrosLib.Repositories
{
    /// <summary>
    /// Repository class for handling database calls for UserInformation objects
    /// </summary>
    internal class UserInformationRepository : IUserInformationRepository
    {
        private readonly IDatabase _database;

        internal UserInformationRepository(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Creates a userinformation entity in the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns>true or false</returns>
        public async Task<bool> CreateAsync(UserInformation createEntity)
        {
            int affectedRows = 0;

            // Create dbcommand with parameters
            DbCommand command = new SqlCommand("spCreateUserInformation");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@UserId",createEntity.Id},
                {"@newFirstName",createEntity.FirstName},
                {"@newLastName",createEntity.LastName},
                {"@newEmail",createEntity.Email},
                {"@newAddress",createEntity.Address},
                {"@newZipcode",createEntity.Zipcode},
                {"@newCity",createEntity.City},
                {"@newPhone",createEntity.Phone}
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
        /// Deletes a userinformation entity in the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteAsync(UserInformation deleteEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spDeleteUserInformation");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@UserId",deleteEntity.Id}
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
        /// Gets all userinformation entities from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserInformation>> GetAllAsync()
        {
            List<UserInformation> userInformations = new List<UserInformation>();

            // Create dbcommand
            DbCommand command = new SqlCommand("spGetAllUserInformations");
            command.CommandType = CommandType.StoredProcedure;

            // Get datareader with result from dbcommand
            using var dataReader = await _database.ExecuteQueryAsync(command);
            if (dataReader.HasRows == false)
            {
                await _database.CloseConnectionAsync();
                return userInformations;
            }
            else
            {
                while (await dataReader.ReadAsync())
                {
                    UserInformation userInformation = UserInformationFactory.CreateUserInformation((int?)dataReader.GetInt32("id") ?? 0,
                        dataReader.GetString("name") ?? "", dataReader.GetString("lastName") ?? "", dataReader.GetString("email") ?? "",
                        dataReader.GetString("address") ?? "", dataReader.GetString("zipcode") ?? "", dataReader.GetString("city") ?? "",
                        dataReader.GetString("phone") ?? "");
                    userInformations.Add(userInformation);
                }
                await _database.CloseConnectionAsync();
                return userInformations;
            }
        }

        /// <summary>
        /// Gets a specific userinformation entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UserInformation> GetByIdAsync(int id)
        {
            // Create dbcommand
            DbCommand command = new SqlCommand("spGetUserInformationById");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@UserId",id}
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
                UserInformation user = null;
                while (dataReader.Read())
                {
                    user = UserInformationFactory.CreateUserInformation((int?)dataReader.GetInt32("id") ?? 0, dataReader.GetString("firstname") ?? "",
                        dataReader.GetString("lastName") ?? "", dataReader.GetString("email") ?? "", dataReader.GetString("address") ?? "",
                        dataReader.GetString("zipcode") ?? "", dataReader.GetString("city") ?? "", dataReader.GetString("phone") ?? "");
                }
                await _database.CloseConnectionAsync();
                return await Task.FromResult(user);
            }
        }

        /// <summary>
        /// Updates a userinformation entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateAsync(UserInformation updateEntity)
        {
            int affectedRows = 0;

            // Create dbcommand
            DbCommand command = new SqlCommand("spUpdateUserInformation");
            command.CommandType = CommandType.StoredProcedure;
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@UserId",updateEntity.Id},
                {"@newFirstName",updateEntity.FirstName},
                {"@newLastName",updateEntity.LastName},
                {"@newEmail",updateEntity.Email},
                {"@newAddress",updateEntity.Address},
                {"@newZipcode",updateEntity.Zipcode},
                {"@newCity",updateEntity.City},
                {"@newPhone",updateEntity.Phone}
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
