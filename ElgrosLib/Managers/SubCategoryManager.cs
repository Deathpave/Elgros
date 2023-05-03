using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;
using ElgrosLib.Logs;

namespace ElgrosLib.Managers
{
    /// <summary>
    /// Manager class for handling SubCategory objects
    /// </summary>
    public class SubCategoryManager : ISubCategoryManager
    {
        private readonly SubCategoryRepository _repository;

        public SubCategoryManager(IDatabase database)
        {
            _repository = new SubCategoryRepository(database);
        }

        /// <summary>
        /// Converts variables into a SubCategory object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="categoryId"></param>
        /// <param name="id"></param>
        /// <returns>SubCategory</returns>
        public SubCategory ConvertToSubCategory(string name, int categoryId, int id = 0)
        {
            try
            {
                return SubCategoryFactory.CreateSubCategory(id, name, categoryId);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"SubCategoryManager could not convert data to subcategory\n{e.Message}", LogTypes.Database).Result);
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
        /// Saves a SubCategory object to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns>True or False</returns>
        public Task<bool> CreateAsync(SubCategory createEntity)
        {
            try
            {
                return _repository.CreateAsync(createEntity);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"SubCategoryManager could not create subcategory\n{e.Message}", LogTypes.Database).Result);
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
        /// Deletes a SubCategory entity from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns>True or False</returns>
        public Task<bool> DeleteAsync(SubCategory deleteEntity)
        {
            try
            {
                return _repository.DeleteAsync(deleteEntity);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"SubCategoryManager could not delete subcategory\n{e.Message}", LogTypes.Database).Result);
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
        /// Gets all SubCategory entities from the databse
        /// </summary>
        /// <returns>IEnumerable with all SubCategories</returns>
        public Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            try
            {
                return _repository.GetAllAsync();
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"SubCategoryManager could not get all subcategories\n{e.Message}", LogTypes.Database).Result);
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
        /// Gets a specific SubCategory entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SubCategory</returns>
        public Task<SubCategory> GetByIdAsync(int id)
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
                    MessageTypes.Error, $"SubCategoryManager could get subcategory by id\n{e.Message}", LogTypes.Database).Result);
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
        /// Updates a SubCategory entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns>True or False</returns>
        public Task<bool> UpdateAsync(SubCategory updateEntity)
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
                    MessageTypes.Error, $"SubCategoryManager could not update subcategory\n{e.Message}", LogTypes.Database).Result);
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
        /// Logs an error locally in case of a missing database connection
        /// </summary>
        /// <param name="exception"></param>
        public void LogErrorLocally(Exception exception)
        {
            LogManager.GetLogManager(null).CreateAsync(
                   LogManager.GetLogManager(null).ConvertToLog(
                   MessageTypes.Error, $"SubCategoryManager could not write log to database\n{exception.Message}", LogTypes.File).Result);
        }
    }
}
