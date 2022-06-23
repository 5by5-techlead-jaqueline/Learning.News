using Newtonsoft.Json;
using System.Collections.Generic;

namespace _5by5.Learning.News.CrossCutting.Configuration.Models
{
    public class PreferencesSettings
    {
        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("countries")]
        public List<string> Countries { get; set; }
    }
}
