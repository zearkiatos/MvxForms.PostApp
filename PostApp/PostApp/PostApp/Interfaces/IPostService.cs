using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Interfaces
{
    /// <summary>
    /// Interface to build all method associate to CRUD process for Post data.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05/06/2018</date>
    /// <email>caprilespe@outlook.com</email>
    public interface IPostService
    {

        /// <summary>
        /// Method for get list of Post.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>05/06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <returns>List of Post.</returns>
        List<Post> GetPosts();

        /// <summary>
        /// Method for get a Post by Id.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>05/06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <param name="PostId">Post key Id</param>
        /// <returns>Post by specifit post Id.</returns>
        Post GetPostById(int PostId);


    }
}
