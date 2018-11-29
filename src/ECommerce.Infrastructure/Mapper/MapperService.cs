using AutoMapper;
using ECommerce.Domain.Core;
using ECommerce.Infrastructure.Mapper.Profiles;
using System;

namespace ECommerce.Infrastructure.Mapper
{
    public sealed class MapperService : IMapperService
    {
        private readonly IMapper mapper;

        public MapperService()
        {
            this.mapper = new AutoMapper.Mapper(
                new MapperConfiguration(
                    x =>
                    {
                        x.AddProfile(new EntityToDtoProfile());
                        x.AddProfile(new DtoToEntityProfile());
                        x.CreateMap<object, Type>();
                    }));
        }

        public object Map(object source, Type destinationType)
        {
            if (source == null)
                throw new ArgumentException(nameof(source));

            if (destinationType == null)
                throw new ArgumentException(nameof(destinationType));

            return this.mapper.Map(source, destinationType);
        }

        public TDestination Map<TDestination>(object source)
        {
            if (source == null)
                throw new ArgumentException(nameof(source));

            return this.mapper.Map<TDestination>(source);
        }

        public void Map(object source, object destination)
        {
            if (source == null)
                throw new ArgumentException(nameof(source));

            if (destination == null)
                throw new ArgumentException(nameof(destination));

            this.mapper.Map(source, destination);
        }
    }
}
