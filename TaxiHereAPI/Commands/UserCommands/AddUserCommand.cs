using MediatR;
using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHereAPI.Commands.UserCommands;

public record AddUserCommand(RegisterDTO newUser) : IRequest;
