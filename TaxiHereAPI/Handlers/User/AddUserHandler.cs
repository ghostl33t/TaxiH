using MediatR;
using TaxiHereAPI.Commands.UserCommands;
using TaxiHereAPI.Repositories.User;

namespace TaxiHereAPI.Handlers.User;
public class AddUserHandler : IRequestHandler<AddUserCommand>
{
    private readonly IUserRepository _userRepository;
    public AddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    async Task IRequestHandler<AddUserCommand>.Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.CreateUserAsync(request.newUser);
    }
}
