using MediatR;
using TaxiHFunc.Commands;
using TaxiHFunc.Repositories.UserRelated;

namespace TaxiHFunc.Handlers;

public class AddUserTokenHandler : IRequestHandler<AddUserTokenCommand>
{
    private readonly IUserRepository _userRepository;
    public AddUserTokenHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    async Task IRequestHandler<AddUserTokenCommand>.Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.SaveTokenForUserAsync(request.userToken);
    }
}
