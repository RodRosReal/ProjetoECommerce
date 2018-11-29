using ECommerce.Domain.Core;
using ECommerce.Domain.Entities.Relacional;
using P2A.Leads.Domain.Specifications;

namespace ECommerce.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetUserByLogin(UsuarioByLoginSpec spec);
    }
}
