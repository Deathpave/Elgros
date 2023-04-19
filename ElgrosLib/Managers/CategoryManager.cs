using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Repositories;

namespace ElgrosLib.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly CategoryRepository _repository;

        public CategoryManager(IDatabase database)
        {
            _repository = new CategoryRepository(database);
        }

        public Category ConvertToCategory(string name)
        {
            return CategoryFactory.CreateCategory(name);
        }

        public Task<bool> CreateAsync(Category createEntity)
        {
            return _repository.CreateAsync(createEntity);
        }

        public Task<bool> DeleteAsync(Category deleteEntity)
        {
            return _repository.DeleteAsync(deleteEntity);
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(Category updateEntity)
        {
            return _repository.UpdateAsync(updateEntity);
        }
    }
}
