using System.Threading;
using System.Threading.Tasks;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Repositories;
using MediatR;

namespace _5by5.Learning.News.Infrastructure.Data.Query.Queries.v1.User.Get
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, GetUserCommandResponse>
    {
        private readonly UserRepository _userRepository;
        public GetUserCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetUserCommandResponse> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            var result = _userRepository.Get(request.Id);
            var response = new GetUserCommandResponse { Id = result.Id, FirstName = result.FirstName, LastName = result.LastName, UserName = result.UserName,
                Preferences = (new GetUserCommandResponse.Preference { Category = result.Preferences.Category, Country = result.Preferences.Country }) };
            return response;
        }
    }
}