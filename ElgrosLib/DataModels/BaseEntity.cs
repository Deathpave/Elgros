namespace ElgrosLib.DataModels
{
    /// <summary>
    /// Super class for all entities
    /// </summary>
    public abstract class BaseEntity
    {
        private long _id;
        public long Id { get { return _id; } }

        public BaseEntity(long id)
        {
            _id = id;
        }
    }
}