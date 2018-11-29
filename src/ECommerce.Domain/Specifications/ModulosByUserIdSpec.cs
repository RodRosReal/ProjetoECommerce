using ECommerce.Domain.Core;
using ECommerce.Domain.Entities.Relacional;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace P2A.Leads.Domain.Specifications
{
    public class ModulosByUserIdSpec : BaseSpecification<Modulo>
    {
        private int Id { get; set; }

        public ModulosByUserIdSpec(int id)
        {
            this.Id = id;
        }

        public override string Description => $"";

        protected override Expression<Func<Modulo, bool>> GetFinalExpression() => x => x.UsuarioModulo.Any(y=>y.UsuarioId == this.Id);
    }
}
