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

            var parents = parentsModules.Where(x=> children.Select(y=>y.ModuloIdPai).Contains(x.Id)).OrderBy(x => x.Ordem).ToList();

            return parents.Select(x => new ModuloDto()
            {
                Id = x.Id,
                ModuloIdPai = x.ModuloIdPai,
                Nome = x.Nome,
                Link = x.Link,
                Ordem = x.Ordem,
                SubModulos = children
                    .Where(y => y.ModuloIdPai == x.Id)
                    .Select(y => new ModuloDto()
                    {
                        Id = y.Id,
                        ModuloIdPai = y.ModuloIdPai,
                        Nome = y.Nome,
                        Link = y.Link,
                        Ordem = y.Ordem,
                    }).ToList()
            }).ToList();
        }
    }
}
