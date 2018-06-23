using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Models
{
    public class Repos
    {
        #region Attributes
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }
        #endregion

    }
}
