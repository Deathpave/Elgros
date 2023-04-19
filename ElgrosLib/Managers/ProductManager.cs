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

        public Product ConvertToProduct(string name, string description, double price, double quantity, string photoUrl, int categoryId, int subCategoryId)
        {
            return ProductFactory.CreateProduct(name, description, price, quantity, photoUrl, categoryId, subCategoryId);
        }

        public Task<bool> CreateAsync(Product createEntity)
        {
            return _repository.CreateAsync(createEntity);
        }

        public Task<bool> DeleteAsync(Product deleteEntity)
        {
            return _repository.DeleteAsync(deleteEntity);
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(Product updateEntity)
        {
            return _repository.UpdateAsync(updateEntity);
        }
    }
}
