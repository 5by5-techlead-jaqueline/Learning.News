using Newtonsoft.Json;

namespace _5by5.Learning.News.CrossCutting.Configuration.Models
{
    public class NoticesApi
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("UrlNewsApi")]
        public string UrlNewsApi { get; set; }
    }
}
