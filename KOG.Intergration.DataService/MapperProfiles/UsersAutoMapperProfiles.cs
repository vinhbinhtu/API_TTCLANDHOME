using AutoMapper;
using KOG.Intergration.Entity.Models;
using KOG.Intergration.Models;

namespace KOG.Intergration.DataService.MapperProfiles
{
    public class UsersAutoMapperProfiles : Profile
    {
        public UsersAutoMapperProfiles()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
