using System.Threading;
using System.Threading.Tasks;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Repositories;
using MediatR;

namespace _5by5.Learning.News.Domain.Commands.v1.User.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly UserRepository _userRepository;
        public DeleteUserCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _userRepository.Remove(request.Id);
            return Unit.Value;
        }
    }
}
