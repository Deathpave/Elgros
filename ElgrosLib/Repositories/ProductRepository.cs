using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using System.Data.Common;

namespace ElgrosLib.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly IDatabase _database;

        public ProductRepository(IDatabase database)
        {
            _database = database;
        }

        public Task<bool> CreateAsync(Product createEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Product deleteEntity)
        {
            throw new NotImplementedException()
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Product updateEntity)
        {
            throw new NotImplementedException();
        }
    }
}
