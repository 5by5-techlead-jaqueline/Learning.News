using System;
using System.Collections.Generic;
using System.Text;

namespace _5by5.Learning.News.Infrastructure.Service.Services
{
    public class NewsApiResponse
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
        public class Article
        {
            public Source Source { get; set; }
            public object Author { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
            public string UrlToImage { get; set; }
            public DateTime PublishedAt { get; set; }
            public string Content { get; set; }
        }
        public class Source
        {
            public object Id { get; set; }
            public string Name { get; set; }
        }
    }

}
