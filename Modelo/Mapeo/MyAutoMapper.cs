using AutoMapper;

namespace Modelo.Mapeo
{
    public static class MyAutoMapper <TSource,TDestination> /*: Profile*/
    {
        private static Mapper _myMapper = new Mapper(new MapperConfiguration(
            cfg => {
                cfg.CreateMap<TSource, TDestination>().ReverseMap();
                cfg.CreateMap<DateTime, string>().ConvertUsing(dt => dt.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            ));
        public static TDestination Map(TSource source)
        {
            return _myMapper.Map<TDestination>(source);
        }
        public static List<TDestination> MapList (List<TSource> source)
        {
            var List=new List<TDestination>();

            source.ForEach(x => { List.Add(Map(x)); });

            return List;
        }
    }
}


//usar
//modeloprueba --modelo
//prueba --variable modelo que trae los datos

//entiyty variable = MyAutoMapper<pruebaprueba, modelo>.Map(prueba);

//------Lista
//List<entiyty> variable = MyAutoMapper<pruebaprueba, modelo>.Map(List<prueba>);