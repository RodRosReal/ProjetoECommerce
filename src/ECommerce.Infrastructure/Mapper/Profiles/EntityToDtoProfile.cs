using AutoMapper;
using ECommerce.Domain.Dtos;
using ECommerce.Domain.Entities.Relacional;

namespace ECommerce.Infrastructure.Mapper.Profiles
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            this.CreateMap<Modulo, ModuloDto>();
            this.CreateMap<Usuario, UsuarioDto>();

            //this.CreateMap<Teste, TesteDto>()
            //    .ForMember(x => x.id2, source => source.MapFrom(from => from.id));
        }
    }
}
