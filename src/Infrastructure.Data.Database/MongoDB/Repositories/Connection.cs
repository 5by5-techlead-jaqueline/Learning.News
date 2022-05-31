using _5by5.Learning.News.CrossCutting.Configuration;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Interfaces;
using System.Linq;

namespace _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Repositories
{
    public class Connection : IConnection
    {
        public string UserColletionName { get; set; } = AppSettings.Settings.DatabaseSettings.FirstOrDefault(x => x.Id == "mongo").UserCollectionName;
        public string ConnectionString { get; set; } = AppSettings.Settings.DatabaseSettings.FirstOrDefault(x => x.Id == "mongo").ConnectionString;
        public string DatabaseName { get; set; } = AppSettings.Settings.DatabaseSettings.FirstOrDefault(x => x.Id == "mongo").DatabaseName;
    }
}
