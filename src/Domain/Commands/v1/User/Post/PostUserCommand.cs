using System.Collections.Generic;
using MediatR;

namespace _5by5.Learning.News.Domain.Commands.v1.User.Post
{
    public class PostUserCommand : IRequest<PostUserCommandResponse>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
