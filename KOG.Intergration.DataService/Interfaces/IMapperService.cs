namespace KOG.Intergration.DataService.Interfaces
{
    public interface IMapperService
    {
        TDestination ConvertTo<TSource, TDestination>(TSource source);
    }
}
