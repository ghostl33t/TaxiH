using MediatR;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHFunc.Queries.UserQueries;
using TaxiHFunc.Repositories.UserRelated;

namespace TaxiHFunc.Handlers;
public class GetUserDataHandler : IRequestHandler<GetUserDataQuery, UserDataDTO>
{
    private readonly IUserRepository _userRepository;
    public GetUserDataHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserDataDTO> Handle(GetUserDataQuery userQuery, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUserByUsernameAsync(userQuery.userName);
    }
}
