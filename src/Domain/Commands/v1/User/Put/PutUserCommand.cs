using System.Collections.Generic;
using MediatR;
using static _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Entities.UserEntity;

namespace _5by5.Learning.News.Domain.Commands.v1.User.Put
{
    public class PutUserCommand : IRequest<PutUserCommandResponse>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Preference Preferences{ get; set; }
        public class Preference
        {
            public List<string> Category { get; set; }
            public string Country { get; set; }

        }
    }
}
