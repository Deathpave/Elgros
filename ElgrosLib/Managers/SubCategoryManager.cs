using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;
using ElgrosLib.Logs;

namespace ElgrosLib.Managers
{
    public class SubCategoryManager : ISubCategoryManager
    {
        private readonly SubCategoryRepository _repository;

        public SubCategoryManager(IDatabase database)
        {
            _repository = new SubCategoryRepository(database);
        }

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

        public void LogErrorLocally(Exception exception)
        {
            LogManager.GetLogManager(null).CreateAsync(
                   LogManager.GetLogManager(null).ConvertToLog(
                   MessageTypes.Error, $"SubCategoryManager could not write log to database\n{exception.Message}", LogTypes.File).Result);
        }
    }
}
