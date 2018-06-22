using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Models
{
    public class Post
    {
        #region Attributes
            [JsonProperty("userId")]
            public int UserId { get; set; }
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("body")]
            public string Body { get; set; }
        #endregion
    }
}
