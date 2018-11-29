using ECommerce.Domain.Core;
using ECommerce.Domain.Dtos;
using ECommerce.Domain.Entities.Relacional;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Factories
{
    public interface IModuloFactory : IFactory
    {
        List<ModuloDto> CreateListModules(List<Modulo> parentsModules, List<Modulo> modules);
    }
}
