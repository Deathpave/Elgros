using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;

namespace ElgrosLib.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        public Task<bool> CreateAsync(Product createEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Product deleteEntity)
        {
            throw new NotImplementedException();
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
