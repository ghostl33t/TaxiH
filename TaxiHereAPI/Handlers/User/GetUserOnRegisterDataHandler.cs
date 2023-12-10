using MediatR;
using TaxiHDataTransferObjects.DTOs.ReqResRelated;
using TaxiHereAPI.Queries.UserQueries;
using TaxiHereAPI.Repositories.User;

namespace TaxiHereAPI.Handlers.User;
public class GetUserOnRegisterDataHandler : IRequestHandler<GetUserOnRegisterDataQuery, ResponseDTO>
{
    private readonly IUserRepository _userRepository;
    public GetUserOnRegisterDataHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ResponseDTO> Handle(GetUserOnRegisterDataQuery request, CancellationToken cancellationToken)
    {
        var response = new ResponseDTO();

        var validation = await _userRepository.UsernameInUseAsync(request.newUser.Username);
        response = ValidateField(validation, "Username", request.newUser.Username);
        if (ValidationFailed(response)) { return  response; }

        validation = await _userRepository.EmailInUseAsync(request.newUser.Email);
        response = ValidateField(validation, "Email", request.newUser.Email);
        if (ValidationFailed(response)) { return response; }

        validation = await _userRepository.PhoneInUseAsync(request.newUser.Phone);
        response = ValidateField(validation, "Phone", request.newUser.Phone);
        if (ValidationFailed(response)) { return response; }

        response.StatusCode = 201;
        response.Message = $"User '{request.newUser.Username}' created successfully!";

        return response;
    }
    private ResponseDTO ValidateField(bool validation, string fieldName, string context)
    {
        if (validation)
        {
            return new ResponseDTO
            {
                StatusCode = 400,
                Message = $"{ fieldName } '{ context }' is already in use."
            };
        }
        return new ResponseDTO();
    }
    private bool ValidationFailed(ResponseDTO res)
    {
        if (res.StatusCode == 400)
            return true;

        return false;
    }
}
