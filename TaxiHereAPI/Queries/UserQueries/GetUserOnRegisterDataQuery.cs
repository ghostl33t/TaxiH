using MediatR;
using TaxiHereAPI.Models.DTO;
using TaxiHereAPI.Services.ResponseService;

namespace TaxiHereAPI.Queries.UserQueries;
public record GetUserOnRegisterDataQuery(RegisterDTO newUser) : IRequest<ResponseInstance>;
