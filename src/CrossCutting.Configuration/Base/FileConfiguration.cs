using Newtonsoft.Json;
using System;
using System.IO;

namespace _5by5.Learning.News.CrossCutting.Configuration.Base
{
    [Serializable]
    public static class FileConfiguration<TSetting> where TSetting : AppSetting
    {
        public static TSetting GetSettingsFromDifferentFile(string filename)
        {
            TSetting data;
            using (StreamReader streamReader = File.OpenText(filename))
            {
                data = JsonConvert.DeserializeObject<TSetting>(streamReader.ReadToEnd());
            }
            return data;
        }
    }
}
