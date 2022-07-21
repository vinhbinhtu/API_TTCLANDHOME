using AutoMapper;
using KOG.Intergration.DataService.Interfaces;

namespace KOG.Intergration.DataService.Services
{
    public class MapperService : IMapperService
    {
		private readonly IMapper mapper;

		public MapperService(IMapper mapper)
		{
			this.mapper = mapper;
		}

		public TDestination ConvertTo<TSource, TDestination>(TSource source)
		{
			var converted = mapper.Map<TDestination>(source);
			return converted;
		}
	}
}
