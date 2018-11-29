using ECommerce.Domain.Entities.Relacional;
using ECommerce.Domain.Repositories;
using P2A.Leads.Domain.Specifications;
using System;

namespace ECommerce.Infrastructure.Repositories.Relational
{
    public class UsuarioRepository : RelationalRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository()
        {
        }

        public Usuario GetUserByLogin(UsuarioByLoginSpec spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Get(spec);
        }
    }
}
