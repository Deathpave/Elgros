namespace ElgrosLib.DataModels
{
    public class SubCategory : BaseEntity
    {
        private string _name;
        private int _categoryId;

        public string Name { get { return _name; } }
        public int CategoryId { get { return _categoryId; } }

        public SubCategory(int id, string name, int categoryId) : base(id)
        {
            _name = name;
            _categoryId = categoryId;
        }
    }
}
