using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPlaces.Model
{
    public class Place
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url_photo")]
        public string UrlPhoto { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
