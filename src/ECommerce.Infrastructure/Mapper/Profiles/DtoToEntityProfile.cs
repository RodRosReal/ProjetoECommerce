using AutoMapper;
using ECommerce.Domain.Dtos;
using ECommerce.Domain.Entities.Relacional;

namespace ECommerce.Infrastructure.Mapper.Profiles
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            this.CreateMap<ModuloDto, Modulo>();
            this.CreateMap<UsuarioDto, Usuario>();

            //this.CreateMap<TesteDto, Teste>()
            //    .ForMember(x => x.id, source => source.MapFrom(from => from.id2));
        }
    }
}
