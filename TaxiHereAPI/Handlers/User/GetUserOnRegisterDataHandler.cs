using MediatR;
using TaxiHereAPI.Queries.UserQueries;
using TaxiHereAPI.Repositories.User;
using TaxiHereAPI.Services.ResponseService;

namespace TaxiHereAPI.Handlers.User;
public class GetUserOnRegisterDataHandler : IRequestHandler<GetUserOnRegisterDataQuery, ResponseInstance>
{
    private readonly IUserRepository _userRepository;
    public GetUserOnRegisterDataHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ResponseInstance> Handle(GetUserOnRegisterDataQuery request, CancellationToken cancellationToken)
    {
        var response = new ResponseInstance();

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
        response.Message = $"User '{request.newUser.Email}' created successfully!";

        return response;
    }
    private ResponseInstance ValidateField(bool validation, string fieldName, string context)
    {
        if (validation)
        {
            return new ResponseInstance
            {
                StatusCode = 400,
                Message = $"{ fieldName } '{ context }' is already in use."
            };
        }
        return new ResponseInstance();
    }
    private bool ValidationFailed(ResponseInstance res)
    {
        if (res.StatusCode == 400)
            return true;

        return false;
    }
}
