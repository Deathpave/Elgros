namespace ElgrosLib.DataModels
{
    internal class Category : BaseEntity
    {
        private string _name;

        public string Name { get { return _name; } }

        internal Category(long id, string name) : base(id)
        {
            _name = name;
        }
    }
}
