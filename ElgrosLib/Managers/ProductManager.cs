using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;

namespace ElgrosLib.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly ProductRepository _repository;

        public ProductManager(IDatabase database)
        {
            _repository = new ProductRepository(database);
        }

        public Product ConvertToProduct(string name, string description, double price, double quantity, string photoUrl, int categoryId, int subCategoryId, int id = 0)
        {
            try
            {
                return ProductFactory.CreateProduct(id, name, description, price, quantity, photoUrl, categoryId, subCategoryId);
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"ProductManager could not convert data to product\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"ProductManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }

        public Task<bool> CreateAsync(Product createEntity)
        {
            try
            {
                return _repository.CreateAsync(createEntity);
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"ProductManager could not create product\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"ProductManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }

        public Task<bool> DeleteAsync(Product deleteEntity)
        {
            try
            {
                return _repository.DeleteAsync(deleteEntity);
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"ProductManager could not delete product\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"ProductManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return _repository.GetAllAsync();
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"ProductManager could not get all products\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"ProductManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }

        public Task<Product> GetByIdAsync(int id)
        {
            try
            {
                return _repository.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"ProductManager could not convert get product by id\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"ProductManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }

        public Task<bool> UpdateAsync(Product updateEntity)
        {
            try
            {
                return _repository.UpdateAsync(updateEntity);
            }
            catch (Exception e)
            {
                try
                {
                    LogFactory.CreateLog(Logs.LogTypes.Database, $"ProductManager could not update product\n{e.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
                catch (Exception f)
                {
                    LogFactory.CreateLog(Logs.LogTypes.File, $"ProductManager could not write log to database\n{f.Message}", Logs.MessageTypes.Error).WriteLog();
                    return null;
                }
            }
        }
    }
}
