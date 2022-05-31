using _5by5.Learning.News.CrossCutting.Configuration.Base;
using _5by5.Learning.News.CrossCutting.Configuration.Models;
using Newtonsoft.Json;
using System;

namespace _5by5.Learning.News.CrossCutting.Configuration
{
    public class AppSettings : AppSetting
    {
        public static AppSettings Settings => FileConfiguration<AppSettings>.GetSettingsFromDifferentFile($"{AppDomain.CurrentDomain.BaseDirectory}appsettings.json");

        [JsonProperty("serviceClients")]
        public ServiceClientsSettings[] ServiceClientsSettings { get; set; }

        [JsonProperty("databaseSettings")]
        public DatabaseSettings DatabaseSettings { get; set; }
    }
}
