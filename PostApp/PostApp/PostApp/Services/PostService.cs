using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostApp.Commons;
using PostApp.Interfaces;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Constants.placeholderDomain + "Posts");
            Post post = new Post();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(PostId.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {

                string jsonStr = response.Content.ReadAsStringAsync().Result;
                post = JsonConvert.DeserializeObject<Post>(jsonStr);

            }
            return post;
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Constants.placeholderDomain+"Posts");
            List<Post> posts = new List<Post>();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            if (response.IsSuccessStatusCode)
            {

                string jsonStr = response.Content.ReadAsStringAsync().Result;
                posts = JsonConvert.DeserializeObject<List<Post>>(jsonStr);

            }
            return posts;
        }

        /// <summary>
        /// Method for add a Post.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>17/06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <param name="post">Post object.</param>
        /// <returns>Result if the post save or not.</returns>
        public bool CreatePost(Post post)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Constants.placeholderDomain + "Posts");
            bool result=false;
            string jsonPost = JsonConvert.SerializeObject(post);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonPost);
            var objectContent = new ByteArrayContent(buffer);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = client.PostAsync("",objectContent).Result;

            if (response.IsSuccessStatusCode)
                result = true;
            else
                result = false;

            return result;
        }

        /// <summary>
        /// Method for edit a Post.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>19.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <param name="post">Post object.</param>
        /// <returns>Result if the post save or not.</returns>
        public bool EditPost(Post post)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Constants.placeholderDomain + "Posts/"+post.Id);
            bool result = false;
            string jsonPost = JsonConvert.SerializeObject(post);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonPost);
            var objectContent = new ByteArrayContent(buffer);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PutAsync("", objectContent).Result;

            if (response.IsSuccessStatusCode)
                result = true;
            else
                result = false;

            return result;
        }

        /// <summary>
        /// Method for delete a Post.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>21.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <param name="post">Post object.</param>
        /// <returns>Result if the post was deleted or not.</returns>
        public bool DeletePost(Post post)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Constants.placeholderDomain + "Posts/" + post.Id);
            bool result = false;
            string jsonPost = JsonConvert.SerializeObject(post);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonPost);
            var objectContent = new ByteArrayContent(buffer);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("").Result;

            if (response.IsSuccessStatusCode)
                result = true;
            else
                result = false;

            return result;
        }
    }
}
