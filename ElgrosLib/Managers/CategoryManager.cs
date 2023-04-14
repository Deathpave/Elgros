using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;

namespace ElgrosLib.Managers
{
    internal class CategoryManager : ICategoryManager
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

        public Task<Product> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Product updateEntity)
        {
            throw new NotImplementedException();
        }
    }
}
