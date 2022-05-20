using System;
using System.Collections.Generic;
using System.Text;

namespace _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Interfaces
{
    public interface IConnection
    {
        string UserColletionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
