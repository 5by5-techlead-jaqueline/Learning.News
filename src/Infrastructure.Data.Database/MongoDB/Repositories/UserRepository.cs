using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Entities;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Repositories
{
    public  class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> _users;
        public UserRepository(IConnection settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<UserEntity>(settings.UserColletionName);
        }

        public List<UserEntity> GetAll() =>
            _users.Find(UserEntity => true).ToList();

        public UserEntity Get(string id) =>
            _users.Find<UserEntity>(userEntity => userEntity.Id == id).FirstOrDefault();

        public UserEntity Create(UserEntity userEntity)
        {
            _users.InsertOne(userEntity);
            return userEntity;
        }

        public void Update(string id, UserEntity userEntityIn) =>
            _users.ReplaceOne(userEntity => userEntity.Id == id, userEntityIn);
        

        public void Remove(string id) =>
            _users.DeleteOne(userEntity => userEntity.Id == id);
    }
}
