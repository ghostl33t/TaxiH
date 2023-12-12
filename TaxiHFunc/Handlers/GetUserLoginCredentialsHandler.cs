using MediatR;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHFunc.Queries.UserQueries;
using TaxiHFunc.Repositories.UserRelated;

namespace TaxiHFunc.Handlers;

public class GetUserLoginCredentialsHandler : IRequestHandler<GetUserLoginCredentialsQuery, LoginDTO>
{
    private readonly IUserRepository _userRepository;
    public GetUserLoginCredentialsHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<LoginDTO> Handle(GetUserLoginCredentialsQuery request, CancellationToken cancellationToken)
    {
        var userLoginCreds = await _userRepository.GetUserCredsAsync(request.userToken);
        return userLoginCreds;
    }
}
