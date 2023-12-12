using MediatR;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHFunc.Queries.UserQueries;
using TaxiHFunc.Repositories.UserRelated;

namespace TaxiHFunc.Handlers;

public class GetUserTokenDataHandler : IRequestHandler<GetUserTokenDataQuery, UserDataDTO>
{
    private readonly IUserRepository _userRepository;
    public GetUserTokenDataHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserDataDTO> Handle(GetUserTokenDataQuery userQuery, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUserByTokenAsync(userQuery.token);
    }
}
