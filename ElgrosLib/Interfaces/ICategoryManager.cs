using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    public interface ICategoryManager : IManager<Category>
    {
        public Category ConvertToCategory(string name, int id = 0);
    }
}
