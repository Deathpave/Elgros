using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    /// <summary>
    /// Super class for all repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IRepository<T> : ICRUD<T> where T : BaseEntity
    {
        
    }
}