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
                return CategoryFactory.CreateCategory(name);
            }
            catch (Exception e)
            {
                LogFactory.CreateLog(Logs.LogTypes.File, $"CategoryFactory could not convert data\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
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
                //try
                //{
                //    return Task.FromResult();
                //}
                //catch (Exception f)
                //{
                //    return Task.FromResult();
                //}
            }
            return null;
        }

        public Task<Category> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(Category updateEntity)
        {
            return _repository.UpdateAsync(updateEntity);
        }
    }
}
