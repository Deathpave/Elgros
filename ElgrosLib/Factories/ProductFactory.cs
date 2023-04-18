using ElgrosLib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElgrosLib.Factories
{

    /// <summary>
    /// Factory that handles the creation of product objects
    /// </summary>
    public static class ProductFactory
    {
        /// <summary>
        /// Create product instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Product CreateProduct(string name, string description, double price, double quantity, string photoUrl, int categoryId, int subCategoryId)
        {
            return new Product(0, name, description, price, quantity, photoUrl, categoryId, subCategoryId);
        }
    }
}
