using PostApp.Interfaces;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Services
{
    /// <summary>
    /// Class to build all method associate to CRUD process for User data.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05/06/2018</date>
    /// <email>caprilespe@outlook.com</email>
    class UserService : IUserService
    {
        /// <summary>
        /// Method for get a User by Id.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>05/06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <param name="UserId">User key id.</param>
        /// <returns>Post by specifit User Id.</returns>
        public User GetUserById(int UserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for get list of User.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>05/06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <returns>List of User.</returns>
        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
