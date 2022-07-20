using AutoMapper;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            //config.CreateMap<, >().ReverseMap();
        });

        return mappingConfig;
    }
}