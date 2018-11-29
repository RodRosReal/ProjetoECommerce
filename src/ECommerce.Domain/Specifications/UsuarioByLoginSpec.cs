using ECommerce.Domain.Core;
using ECommerce.Domain.Entities.Relacional;
using System;
using System.Linq.Expressions;

namespace P2A.Leads.Domain.Specifications
{
    public class UsuarioByLoginSpec : BaseSpecification<Usuario>
    {
        private string Login { get; set; }

        public UsuarioByLoginSpec(string login)
        {
            this.Login = login;
        }

        public override string Description => $"";

        protected override Expression<Func<Usuario, bool>> GetFinalExpression() => x => x.Login == this.Login && x.Disponivel == true;
    }
}
