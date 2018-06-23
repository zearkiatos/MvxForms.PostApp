using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Interfaces
{
    /// <summary>
    /// Interface to build all method associate to CRUD process for Repos data.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>21.06.2018</date>
    /// <email>caprilespe@outlook.com</email>
    public interface IReposService
    {
        /// <summary>
        /// Method for get list of Repos by user.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>21.06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <param name="user">Username of Github</param>
        /// <returns>List of Repos.</returns>
        List<Repos> GetReposByUser(string user);
    }
}
