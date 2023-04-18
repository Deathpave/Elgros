namespace ElgrosLib.DataModels
{
    /// <summary>
    /// Super class for all entities
    /// </summary>
    public abstract class BaseEntity
    {
        private int _id;
        public int Id { get { return _id; } }

        internal BaseEntity(int id)
        {
            _id = id;
        }
    }
}