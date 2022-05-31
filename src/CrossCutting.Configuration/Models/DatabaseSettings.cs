using Newtonsoft.Json;

namespace _5by5.Learning.News.CrossCutting.Configuration.Models
{
    public class DatabaseSettings
    {
        [JsonProperty("databaseName")]
        public string DatabaseName { get; set; }

        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }

        [JsonProperty("userCollectionName")]
        public string UserCollectionName { get; set; }
    }
}
