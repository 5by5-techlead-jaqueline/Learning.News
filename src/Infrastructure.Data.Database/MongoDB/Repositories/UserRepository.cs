using System;
using System.Collections.Generic;
using System.Text;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Entities;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Interfaces;
using MongoDB.Driver;

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

        public UserEntity Get(string name) =>
            _users.Find<UserEntity>(userEntity => userEntity.Name == name).FirstOrDefault();

        public UserEntity Create(UserEntity userEntity)
        {
            _users.InsertOne(userEntity);
            return userEntity;
        }

        public void Update(string name, UserEntity userEntityIn) =>
            _users.ReplaceOne(userEntity => userEntity.Name == name, userEntityIn);

        public void Remove(string name) =>
            _users.DeleteOne(userEntity => userEntity.Name == name);
    }
}
