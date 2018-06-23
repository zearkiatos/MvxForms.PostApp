using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Models
{
    public class Owner
    {
        #region Attributes
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        #endregion
    }
}
