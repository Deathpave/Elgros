using ElgrosLib.DataModels;
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
