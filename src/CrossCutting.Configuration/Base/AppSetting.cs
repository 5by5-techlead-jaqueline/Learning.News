using Newtonsoft.Json;

namespace _5by5.Learning.News.CrossCutting.Configuration.Base
{
    public class AppSetting
    {
        [JsonProperty("ApplicationName")]
        public string ApplicationName { get; set; }
    }
}
