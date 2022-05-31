using System;
using System.Collections.Generic;
using System.Text;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Entities;

namespace _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Interfaces
{
    public interface IUserRepository 
    {
        public UserEntity Get(string name);
        public UserEntity Create(UserEntity userEntity);
        public void Update(string id, UserEntity userEntityIn);
        public void Remove(string name);
    }
}
