using PostApp.Interfaces;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Services
{
    /// <summary>
    /// Class to build all method associate to CRUD process for Post data.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05/06/2018</date>
    /// <email>caprilespe@outlook.com</email>
    public class PostService : IPostService
    {

        /// <summary>
        /// Method for get a Post by Id.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>05/06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <param name="PostId">Post key Id</param>
        /// <returns>Post by specifit post Id.</returns>
        public Post GetPostById(int PostId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for get list of Post.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>05/06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <returns>List of Post.</returns>
        public List<Post> GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}
