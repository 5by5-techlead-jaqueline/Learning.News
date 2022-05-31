using Newtonsoft.Json;

namespace _5by5.Learning.News.CrossCutting.Configuration.Models
{
    public class ServiceClientsSettings
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
 
        [JsonProperty("resilience")]
        public ResilienceSettings Resilience { get; set; }
    }

    public class ResilienceSettings
    {
        [JsonProperty("retry")]
        public Retry Retry { get; set; }
    }

    public class Retry
    {
        [JsonProperty("waitDuaration")]
        public int WaitDuaration { get; set; }

        [JsonProperty("attempt")]
        public int Attempt { get; set; }
    }
}

