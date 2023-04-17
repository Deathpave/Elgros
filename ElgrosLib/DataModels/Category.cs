namespace ElgrosLib.DataModels
{
    public class Category : BaseEntity
    {
        private string _name;

        public string Name { get { return _name; } }

        internal Category(int id, string name) : base(id)
        {
            _name = name;
        }
    }
}
