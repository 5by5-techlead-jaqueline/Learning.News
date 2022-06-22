using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace _5by5.Learning.News.Domain.Commands.v1.User.Delete
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public string Id { get; set; }

    }
}
