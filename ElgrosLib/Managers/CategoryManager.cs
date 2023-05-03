using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;
using ElgrosLib.Logs;

namespace ElgrosLib.Managers
{
    /// <summary>
    /// Manager class for handling Category objects
    /// </summary>
    public class CategoryManager : ICategoryManager
    {
        private readonly CategoryRepository _repository;

        public CategoryManager(IDatabase database)
        {
            _repository = new CategoryRepository(database);
        }

        /// <summary>
        /// Converts variables into an object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns>Category</returns>
        public Category ConvertToCategory(string name, int id = 0)
        {
            try
            {
                return CategoryFactory.CreateCategory(id, name);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"CategoryFactory could not convert data\n{e.Message}", LogTypes.Database).Result);
                    return null;
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
                    return null;
                }
            }
        }

        /// <summary>
        /// Saves a new Category entity in the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns>True or False</returns>
        public Task<bool> CreateAsync(Category createEntity)
        {
            try
            {
                bool result = _repository.CreateAsync(createEntity).Result;
                return Task.FromResult(result);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"CategoryManager could not create category\n{e.Message}", LogTypes.Database).Result);
                    return Task.FromResult(false);
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
                    return Task.FromResult(false);
                }
            }
        }

        /// <summary>
        /// Deletes a Category entity from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns>True or False</returns>
        public Task<bool> DeleteAsync(Category deleteEntity)
        {
            try
            {
                bool result = _repository.DeleteAsync(deleteEntity).Result;
                return Task.FromResult(result);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"CategoryManager could not delete category\n{e.Message}", LogTypes.Database).Result);
                    return Task.FromResult(false);
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
                    return Task.FromResult(false);
                }
            }
        }

        /// <summary>
        /// Gets all Category entities from the database
        /// </summary>
        /// <returns>IEnumerable with all Categories</returns>
        public Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                IEnumerable<Category> categories = _repository.GetAllAsync().Result;
                if (categories == null)
                {
                    categories = new List<Category>();
                }
                return Task.FromResult(categories);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"CategoryManager could not get all categories\n{e.Message}", LogTypes.Database).Result);
                    return null;
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets a specific Category entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category</returns>
        public Task<Category> GetByIdAsync(int id)
        {
            try
            {
                return _repository.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"CategoryManager could not get category by id\n{e.Message}", LogTypes.Database).Result);
                    return null;
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
                    return null;
                }
            }
        }

        /// <summary>
        /// Updates a Category entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns>True or False</returns>
        public Task<bool> UpdateAsync(Category updateEntity)
        {
            try
            {
                return _repository.UpdateAsync(updateEntity);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"CategoryManager could not update category\n{e.Message}", LogTypes.Database).Result);
                    return null;
                }
                catch (Exception f)
                {
                    LogErrorLocally(f);
                    return null;
                }
            }
        }

        /// <summary>
        /// Method for creating a local log incase of missing database connection
        /// </summary>
        /// <param name="exception"></param>
        public void LogErrorLocally(Exception exception)
        {
            LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"CategoryManager could not write log to database\n{exception.Message}", LogTypes.File).Result);
        }
    }
}