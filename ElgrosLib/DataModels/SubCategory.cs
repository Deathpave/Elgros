namespace ElgrosLib.DataModels
{
    internal class SubCategory : BaseEntity
    {
        private string _name;
        private int _categoryId;

        public string Name { get { return _name; } }
        public int CategoryId { get { return _categoryId; } }

        public SubCategory(long id, string name, int cagegoryId) : base(id)
        {
            _name = name;
            _categoryId = cagegoryId;
        }
    }
}
