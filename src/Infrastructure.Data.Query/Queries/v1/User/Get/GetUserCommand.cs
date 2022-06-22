using MediatR;

namespace _5by5.Learning.News.Infrastructure.Data.Query.Queries.v1.User.Get
{
    public class GetUserCommand : IRequest<GetUserCommandResponse>
    {
        public string Id { get; set; }
    }
}
