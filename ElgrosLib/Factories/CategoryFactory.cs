﻿using ElgrosLib.DataModels;

namespace ElgrosLib.Factories
{
    /// <summary>
    /// Factory that handles the creation of category objects
    /// </summary>
    public static class CategoryFactory
    {
        /// <summary>
        /// Create category instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Category CreateCategory(string name)
        {
            return new Category(0, name);
        }
    }
}