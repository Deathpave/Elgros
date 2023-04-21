using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;

namespace ElgrosLib.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly CategoryRepository _repository;

        public CategoryManager(IDatabase database)
        {
            _repository = new CategoryRepository(database);
        }

        public Category ConvertToCategory(string name)
        {
            try
            {
                return CategoryFactory.CreateCategory(0, name);
            }
            catch (Exception e)
            {
                LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                        Logs.MessageTypes.Error, $"CategoryFactory could not convert data\n{e.Message}", Logs.LogTypes.File).Result);
                return null;
            }
        }

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
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"CategoryManager could not create category\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return Task.FromResult(false);
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"CategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return Task.FromResult(false);
                }
            }
        }

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
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"CategoryManager could not delete category\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return Task.FromResult(false);
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"CategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return Task.FromResult(false);
                }
            }
        }

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
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"CategoryManager could not get all categories\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"CategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }

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
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"CategoryManager could not get category by id\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"CategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }

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
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"CategoryManager could not update category\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"CategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }
    }
}