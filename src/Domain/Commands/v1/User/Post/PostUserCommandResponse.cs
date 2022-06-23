using System.Collections.Generic;

namespace _5by5.Learning.News.Domain.Commands.v1.User.Post
{
    public class PostUserCommandResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Preference Preferences { get; set; }

        public class Preference
        {
            public string Country { get; set; }
            public List<string> Categories { get; set; }
        }
    }
}