using ElgrosLib.DataModels;

namespace ElgrosLib.Interfaces
{
    /// <summary>
    /// Super class for all managers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IManager<T> : ICRUD<T> where T : BaseEntity
    {
        public void LogErrorLocally(Exception exception);
    }
}
