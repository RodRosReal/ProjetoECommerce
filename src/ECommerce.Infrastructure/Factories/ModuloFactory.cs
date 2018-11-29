using ECommerce.Domain.Dtos;
using ECommerce.Domain.Entities.Relacional;
using ECommerce.Domain.Factories;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Infrastructure.Factories
{
    public class ModuloFactory : IModuloFactory
    {
        public List<ModuloDto> CreateListModules(List<Modulo> parentsModules, List<Modulo> modules)
        {
            var children = modules.OrderBy(x => x.Ordem).ToList();

            var parents = parentsModules.Where(x=> children.Select(y=>y.Modulo_IdPai).Contains(x.Id)).OrderBy(x => x.Ordem).ToList();

            return parents.Select(x => new ModuloDto()
            {
                Id = x.Id,
                Modulo_IdPai = x.Modulo_IdPai,
                Nome = x.Nome,
                Link = x.Link,
                Ordem = x.Ordem,
                SubModulos = children
                    .Where(y => y.Modulo_IdPai == x.Id)
                    .Select(y => new ModuloDto()
                    {
                        Id = y.Id,
                        Modulo_IdPai = y.Modulo_IdPai,
                        Nome = y.Nome,
                        Link = y.Link,
                        Ordem = y.Ordem,
                    }).ToList()
            }).ToList();
        }
    }
}
