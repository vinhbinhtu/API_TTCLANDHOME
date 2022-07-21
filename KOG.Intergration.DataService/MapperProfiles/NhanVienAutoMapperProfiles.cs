using AutoMapper;
using KOG.Intergration.Entity.Models;
using KOG.Intergration.Models.R81DMDT_NhanVien;

namespace KOG.Intergration.DataService.MapperProfiles
{
    public class NhanVienAutoMapperProfiles : Profile
    {
        public NhanVienAutoMapperProfiles()
        {
            CreateMap<DAO_R81DMDT, R81DMDT_NhanVienResponseModel>();
        }
    }
}
