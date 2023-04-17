using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;

namespace ElgrosLib.Managers
{
    internal class SubCategoryManager : ISubCategoryManager
    {
        private readonly SubCategoryRepository _repository;

        public SubCategoryManager(IDatabase database)
        {
            _repository = new SubCategoryRepository(database);
        }

        public Task<bool> CreateAsync(SubCategory createEntity)
        {
            return _repository.CreateAsync(createEntity);
        }

        public Task<bool> DeleteAsync(SubCategory deleteEntity)
        {
            return _repository.DeleteAsync(deleteEntity);
        }

        public Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<SubCategory> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(SubCategory updateEntity)
        {
            return _repository.UpdateAsync(updateEntity);
        }
    }
}
