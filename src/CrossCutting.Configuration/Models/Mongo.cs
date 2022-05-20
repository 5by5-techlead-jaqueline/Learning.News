using Newtonsoft.Json;

namespace _5by5.Learning.News.CrossCutting.Configuration.Models
{
    public class Mongo
    {
        [JsonProperty("databaseName")]
        public string DatabaseName { get; set; }

        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }

        [JsonProperty("userColletionName")]
        public string UserColletionName { get; set; }
    }
}
