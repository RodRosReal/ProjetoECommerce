using ECommerce.Domain.Core;
using ECommerce.Domain.Entities.Relacional;
using P2A.Leads.Domain.Specifications;
using System.Collections.Generic;

namespace ECommerce.Domain.Repositories
{
    public interface IModuloRepository : IRepository<Modulo>
    {
        List<Modulo> GetModulosByUserId(ModulosByUserIdSpec spec);
    }
}
