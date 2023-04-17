namespace ElgrosLib.DataModels
{
    /// <summary>
    /// Super class for all entities
    /// </summary>
    public abstract class BaseEntity
    {
        private int _id;
        public int Id { get { return _id; } }

        public BaseEntity(int id)
        {
            _id = id;
        }
    }
}