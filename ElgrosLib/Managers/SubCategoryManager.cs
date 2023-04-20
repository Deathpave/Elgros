using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;

namespace ElgrosLib.Managers
{
    public class SubCategoryManager : ISubCategoryManager
    {
        private readonly SubCategoryRepository _repository;

        public SubCategoryManager(IDatabase database)
        {
            _repository = new SubCategoryRepository(database);
        }

        public SubCategory ConvertToSubCategory(string name, int categoryId)
        {
            try
            {
                return SubCategoryFactory.CreateSubCategory(0, name, categoryId);
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"SubCategoryManager could not convert data to subcategory\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"SubCategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
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
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"SubCategoryManager could not create subcategory\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"SubCategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
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
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"SubCategoryManager could not delete subcategory\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"SubCategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
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
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"SubCategoryManager could not get all subcategories\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"SubCategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
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
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"SubCategoryManager could get subcategory by id\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"SubCategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
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
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"SubCategoryManager could not update subcategory\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"SubCategoryManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }
    }
}
