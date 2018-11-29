using ECommerce.Domain.Core;
using ECommerce.Domain.Dtos;
using ECommerce.Domain.Entities.Relacional;
using System;
using System.Linq.Expressions;

namespace P2A.Leads.Domain.Specifications
{
    public class UsuariosAllSpec : BaseSpecification<Usuario>
    {
        private UsuarioFilter Filter { get; set; }

        public UsuariosAllSpec(UsuarioFilter filter)
        {
            this.Filter = filter;
        }

        public override string Description => $"";

        protected override Expression<Func<Usuario, bool>> GetFinalExpression() => x =>
        (string.IsNullOrEmpty(this.Filter.NomeLike) || x.Nome.Contains(this.Filter.NomeLike)) &&
        (string.IsNullOrEmpty(this.Filter.LoginLike) || x.Nome.Contains(this.Filter.LoginLike)) &&
        (string.IsNullOrEmpty(this.Filter.EmailLike) || x.Email.Contains(this.Filter.EmailLike));
    }
}
