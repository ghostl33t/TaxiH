using AutoMapper;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHDbContext.DBContext.Models.Domain;

namespace TaxiHereAPI.Profiles;
public class UserProfiles : Profile
{
    public UserProfiles() 
    {
        CreateMap<RegisterDTO, User>();
    }
}
