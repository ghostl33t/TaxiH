using MediatR;
using TaxiHDataTransferObjects.DTOs.ReqResRelated;
using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHereAPI.Queries.UserQueries;
public record GetUserOnRegisterDataQuery(RegisterDTO newUser) : IRequest<ResponseDTO>;
