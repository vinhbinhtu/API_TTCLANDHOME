using AutoMapper;
using KOG.Intergration.Entity.Models;
using KOG.Intergration.Models;

namespace KOG.Intergration.DataService.MapperProfiles
{
    public class RolesAutoMapperProfiles : Profile
    {
        public RolesAutoMapperProfiles()
        {
            CreateMap<RoleEntity, RoleModel>().ReverseMap();
        }
    }
}
