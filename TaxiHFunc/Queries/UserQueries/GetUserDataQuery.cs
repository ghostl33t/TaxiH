using MediatR;
using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Queries.UserQueries;
public record GetUserDataQuery(string userName) : IRequest<UserDataDTO>;
public record GetUserTokenDataQuery(string token) : IRequest<UserDataDTO>;