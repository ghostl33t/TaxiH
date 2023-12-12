using MediatR;
using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Commands;
public record AddUserTokenCommand(TokenDTO userToken) : IRequest;
