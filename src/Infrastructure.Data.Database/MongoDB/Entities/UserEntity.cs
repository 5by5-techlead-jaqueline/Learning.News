using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Entities
{
    public class UserEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Preferences { get; set; }

    }
}

