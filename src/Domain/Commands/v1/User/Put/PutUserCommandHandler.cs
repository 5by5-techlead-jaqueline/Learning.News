using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace _5by5.Learning.News.Domain.Commands.v1.User.Put
{
    public class PutUserCommandHandler : IRequestHandler<PutUserCommand, PutUserCommandResponse>
    {
        private readonly UserRepository _userRepository;
        public PutUserCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PutUserCommandResponse> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {

            var user = _userRepository.Get(request.Id);

            if (user == null) { return null; }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Preferences.Country = request.Preferences.Country;
            user.Preferences.Category = request.Preferences.Category;
            
            _userRepository.Update(request.Id, user);


            var response = new PutUserCommandResponse { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, UserName = user.UserName, 
                Preferences = (new PutUserCommandResponse.Preference {Category = user.Preferences.Category, Country = user.Preferences.Country }) };
            return response;
        }
    }
}
