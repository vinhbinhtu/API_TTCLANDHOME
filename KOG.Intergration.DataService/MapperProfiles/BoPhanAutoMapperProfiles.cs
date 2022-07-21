using AutoMapper;
using KOG.Intergration.Entity.Models;
using KOG.Intergration.Models.R81DMDT_BoPhan;

namespace KOG.Intergration.DataService.MapperProfiles
{
    public class BoPhanAutoMapperProfiles : Profile
    {
        public BoPhanAutoMapperProfiles()
        {
            CreateMap<DAO_R81DMDT, R81DMDT_BoPhanResponseModel>();
        }
    }
}
