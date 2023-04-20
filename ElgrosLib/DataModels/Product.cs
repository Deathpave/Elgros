namespace ElgrosLib.DataModels
{
    public class Product : BaseEntity
    {
        private string _name;
        private string _description;
        private double _price;
        private int _quantity;
        private string _photoUrl;
        private int _categoryId;
        private int _subCategoryId;

        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public double Price { get { return _price; } }
        public int Quantity { get { return _quantity; } }
        public string PhotoUrl { get { return _photoUrl; } }
        public int CategoryId { get { return _categoryId; } }
        public int SubCategoryId { get { return _subCategoryId; } }

        internal Product(int id, string name, string description, double price, int quantity, string photoUrl, int categoryId, int subCategoryId) : base(id)
        {
            _name = name;
            _description = description;
            _price = price;
            _quantity = quantity;
            _photoUrl = photoUrl;
            _categoryId = categoryId;
            _subCategoryId = subCategoryId;
        }
    }
}
