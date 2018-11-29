using ECommerce.Domain.Core;
using ECommerce.Domain.Entities.Relacional;
using System;
using System.Linq.Expressions;

namespace P2A.Leads.Domain.Specifications
{
    public class UsuarioByIdSpec : BaseSpecification<Usuario>
    {
        private int Id { get; set; }

        public UsuarioByIdSpec(int id)
        {
            this.Id = id;
        }

        public override string Description => $"";

        protected override Expression<Func<Usuario, bool>> GetFinalExpression() => x => x.Id == this.Id;
    }
}
