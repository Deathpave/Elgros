﻿using ElgrosLib.DataModels;

namespace ElgrosLib.Factories
{
    /// <summary>
    /// Factory that handles the creation of userinformation objects
    /// </summary>
    public static class UserInformationFactory
    {
        /// <summary>
        /// Create userinformation instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static UserInformation CreateUserInformation(int userId, string name, string lastname, string email, string address, string zipcode, string city, string phone)
        {
            return new UserInformation(0, userId, name, lastname, email, address, zipcode, city, phone);
        }
    }
}
