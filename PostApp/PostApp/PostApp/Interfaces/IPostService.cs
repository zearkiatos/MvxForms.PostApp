using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Interfaces
{
    public interface IPostService
    {
        List<Post> GetPosts();

         Post GetPostById(int PostId);


    }
}
