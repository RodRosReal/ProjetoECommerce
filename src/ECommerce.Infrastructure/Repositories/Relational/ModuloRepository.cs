using ECommerce.Domain.Core;
using ECommerce.Domain.Entities.Relacional;
using ECommerce.Domain.Repositories;
using P2A.Leads.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Infrastructure.Repositories.Relational
{
    public class ModuloRepository : RelationalRepository<Modulo>, IModuloRepository
    {
        public ModuloRepository()
        {
        }

        public List<Modulo> GetModulosByUserId(ModulosByUserIdSpec spec)
        {
            return this.Query(spec);
        }
    }
}
