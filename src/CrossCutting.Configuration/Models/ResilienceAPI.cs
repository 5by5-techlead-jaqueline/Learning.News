using Newtonsoft.Json;

namespace _5by5.Learning.News.CrossCutting.Configuration.Models
{
    public class ResilienceAPI
    {
        [JsonProperty("retry")]
        public RetryAPI Retry { get; set; }

        public class RetryAPI
        {
            [JsonProperty("waitDuaration")]
            public int WaitDuaration { get; set; }
            
            [JsonProperty("attempt")]
            public int Attempt { get; set; }
        }
    }
}