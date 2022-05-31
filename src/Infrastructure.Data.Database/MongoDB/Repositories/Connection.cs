using System;
using System.Collections.Generic;
using System.Text;
using _5by5.Learning.News.CrossCutting.Configuration;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Interfaces;

namespace _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Repositories
{
    public class Connection : IConnection
    {
        public string UserColletionName { get; set; } = AppSettings.Settings.DatabaseSettings.UserCollectionName;
        public string ConnectionString { get; set; } = AppSettings.Settings.DatabaseSettings.ConnectionString;
        public string DatabaseName { get; set; } = AppSettings.Settings.DatabaseSettings.DatabaseName;
    }
}
