﻿using Newtonsoft.Json;

namespace _5by5.Learning.News.CrossCutting.Configuration.Models
{
    public class ServiceClientsSettings
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}