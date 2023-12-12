using AutoMapper;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHDbContext.DBContext.Models.Domain;

namespace TaxiHFunc.Profiles.UserRelated;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDataDTO>();
        CreateMap<User, LoginDTO>();
    }
}
