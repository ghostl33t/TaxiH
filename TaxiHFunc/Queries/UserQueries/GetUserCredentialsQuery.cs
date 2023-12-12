using MediatR;
using TaxiHDataTransferObjects.DTOs.ReqResRelated;
using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Queries.UserQueries;

public record GetUserCredentialsQuery(LoginDTO userCreds) : IRequest<ResponseDTO>;
public record GetUserLoginCredentialsQuery(TokenDTO userToken) : IRequest<LoginDTO>;
