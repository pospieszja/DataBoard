using AutoMapper;
using DataBoard.Core.Domain;
using DataBoard.Infrastructure.DTO;

namespace DataBoard.Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });

            return config.CreateMapper();
        }

    }
}