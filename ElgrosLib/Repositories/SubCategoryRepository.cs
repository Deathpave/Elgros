using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;

namespace ElgrosLib.Repositories
{
    internal class SubCategoryRepository : IRepository<SubCategory>
    {
        public Task<bool> CreateAsync(SubCategory createEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(SubCategory deleteEntity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubCategory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(SubCategory updateEntity)
        {
            throw new NotImplementedException();
        }
    }
}
