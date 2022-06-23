using System.Threading;
using System.Threading.Tasks;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Entities;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Repositories;
using MediatR;

namespace _5by5.Learning.News.Domain.Commands.v1.User.Post
{
    public class PostUserCommandHandler : IRequestHandler<PostUserCommand, PostUserCommandResponse>
    {
        private readonly UserRepository _userRepository;
        public PostUserCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PostUserCommandResponse> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            var result = _userRepository.Create(new UserEntity { FirstName = request.FirstName, LastName = request.LastName, UserName= request.UserName, 
                Password= request.Password, Preferences = new UserEntity.Preference()});

            var response = new PostUserCommandResponse { Id = result.Id, FirstName = result.FirstName, LastName = result.LastName, 
                UserName= result.UserName, Preferences = new PostUserCommandResponse.Preference { Country = null, Categories = null} };

            return response;
        }
    }
}