using _5by5.Learning.News.CrossCutting.Configuration.Base;
using _5by5.Learning.News.CrossCutting.Configuration.Models;
using Newtonsoft.Json;
using System;

namespace _5by5.Learning.News.CrossCutting.Configuration
{
    public class CustomSettings : AppSetting
    {
        public static CustomSettings Settings => FileConfigurationAppSetting<CustomSettings>.GetSettingsFromDifferentFile($"{AppDomain.CurrentDomain.BaseDirectory}customsettings.json");

        [JsonProperty("preferences")]
        public PreferencesSettings Preferences { get; set; }
    }
}