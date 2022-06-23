using System.Collections.Generic;

namespace _5by5.Learning.News.Infrastructure.Data.Query.Queries.v1.User.Get
{
    public class GetUserCommandResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public Preference Preferences { get; set; }
        public class Preference
        {
            public List<string> Category { get; set; }
            public string Country { get; set; }
        }
    }
}