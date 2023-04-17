using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;

namespace ElgrosLib.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        public Task<bool> CreateAsync(Category createEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Category deleteEntity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Category updateEntity)
        {
            throw new NotImplementedException();
        }
    }
}
