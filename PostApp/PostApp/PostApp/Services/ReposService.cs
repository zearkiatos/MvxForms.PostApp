using Newtonsoft.Json;
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
    /// Interface to build all method associate to CRUD process for Repos data.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>21.06.2018</date>
    /// <email>caprilespe@outlook.com</email>
    public class ReposService : IReposService
    {
        /// <summary>
        /// Method for get list of Repos by user.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>21.06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <param name="user">Username of Github</param>
        /// <returns>List of Repos.</returns>
        public List<Repos> GetReposByUser(string user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Constants.gitHubDomain + "users/"+user+"/repos");
            List<Repos> repos = new List<Repos>();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "845080decbdb28c74eecba23bfacf9138d0ef744");
            client.DefaultRequestHeaders.Add("User-Agent","PostApp");
            HttpResponseMessage response = client.GetAsync("").Result;

            if (response.IsSuccessStatusCode)
            {

                string jsonStr = response.Content.ReadAsStringAsync().Result;
                repos = JsonConvert.DeserializeObject<List<Repos>>(jsonStr);

            }
            return repos;
        }
    }
}
