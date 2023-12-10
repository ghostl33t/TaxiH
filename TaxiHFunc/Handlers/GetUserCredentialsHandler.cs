using MediatR;
using TaxiHDataTransferObjects.DTOs.ReqResRelated;
using TaxiHFunc.Queries.UserQueries;
using TaxiHFunc.Repositories.UserRelated;

namespace TaxiHFunc.Handlers;

public class GetUserCredentialsHandler : IRequestHandler<GetUserCredentialsQuery, ResponseDTO>
{
    private readonly IUserRepository _userRepository;
    public GetUserCredentialsHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ResponseDTO> Handle(GetUserCredentialsQuery request, CancellationToken cancellationToken)
    {
        var loggedInStatus = await _userRepository.LoginUser(request.userCreds);
        var res = new ResponseDTO();
        if (loggedInStatus)
        {
           res.StatusCode = 200;
           res.Message = $"User '{request.userCreds.Username}' logged in successfuly!";
        }
        else
        {
            res.StatusCode = 400;
            res.Message = $"Invalid credentials!";
        }
        return res;
    }
}
