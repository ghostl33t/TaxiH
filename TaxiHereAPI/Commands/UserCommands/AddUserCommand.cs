using MediatR;
using TaxiHereAPI.Models.DTO;

namespace TaxiHereAPI.Commands.UserCommands;

public record AddUserCommand(RegisterDTO newUser) : IRequest;
