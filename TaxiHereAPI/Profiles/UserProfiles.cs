using AutoMapper;
using TaxiHereAPI.Models.Domain;
using TaxiHereAPI.Models.DTO;

namespace TaxiHereAPI.Profiles;
public class UserProfiles : Profile
{
    public UserProfiles() 
    {
        CreateMap<RegisterDTO, User>();
    }
}
