using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;
using ElgrosLib.Logs;

namespace ElgrosLib.Managers
{
    /// <summary>
    /// Manager class for handling Product objects
    /// </summary>
    public class ProductManager : IProductManager
    {
        private readonly ProductRepository _repository;
        private IEnumerable<Product> _products;
        private TimeSpan _lastLoaded;

        public ProductManager(IDatabase database)
        {
            _repository = new ProductRepository(database);
        }

        /// <summary>
        /// Converts variables to a Product object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <param name="photoUrl"></param>
        /// <param name="categoryId"></param>
        /// <param name="subCategoryId"></param>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        public Product ConvertToProduct(string name, string description, double price, int quantity, string photoUrl, int categoryId, int subCategoryId, int id = 0)
        {
            try
            {
                return ProductFactory.CreateProduct(id, name, description, price, quantity, photoUrl, categoryId, subCategoryId);
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"ProductManager could not convert data to product\n{e.Message}", LogTypes.File).Result);
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
        /// Saves a Product entity to the database
        /// </summary>
        /// <param name="createEntity"></param>
        /// <returns>True or False</returns>
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
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"ProductManager could not create product\n{e.Message}", LogTypes.Database).Result);
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
        /// Deletes a Product entity from the database
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <returns>True or False</returns>
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
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"ProductManager could not delete product\n{e.Message}", LogTypes.Database).Result);
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
        /// Gets all Product entities from the database
        /// </summary>
        /// <returns>IEnumerable with all Products</returns>
        public Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                if (_lastLoaded.Add(new TimeSpan(0, 5, 0)) < DateTime.Now.TimeOfDay || _products == null)
                {
                    _products = _repository.GetAllAsync().Result;
                    _lastLoaded = DateTime.Now.TimeOfDay;
                    return Task.FromResult(_products);
                }
                else
                {
                    return Task.FromResult(_products);
                }
            }
            catch (Exception e)
            {
                try
                {
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"ProductManager could not get all products\n{e.Message}", LogTypes.Database).Result);
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
        /// Gets a specific Product entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product</returns>
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
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"ProductManager could not convert get product by id\n{e.Message}", LogTypes.Database).Result);
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
        /// Updates a Product entity in the database
        /// </summary>
        /// <param name="updateEntity"></param>
        /// <returns>True or False</returns>
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
                    LogManager.GetLogManager(null).CreateAsync(
                    LogManager.GetLogManager(null).ConvertToLog(
                    MessageTypes.Error, $"ProductManager could not update product\n{e.Message}", LogTypes.Database).Result);
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
                    MessageTypes.Error, $"ProductManager could not write log to database\n{exception.Message}", LogTypes.File).Result);
        }
    }
}
