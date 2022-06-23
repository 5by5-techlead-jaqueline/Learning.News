using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Entities
{
    public class UserEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Preference Preferences { get; set; }
        public class Preference
        {
            public List<string> Category { get; set; }
            public string Country { get; set; }

        }
    }
}