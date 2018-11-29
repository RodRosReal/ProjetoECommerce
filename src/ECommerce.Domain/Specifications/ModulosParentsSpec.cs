using ECommerce.Domain.Core;
using ECommerce.Domain.Entities.Relacional;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace P2A.Leads.Domain.Specifications
{
    public class ModulosParentsSpec : BaseSpecification<Modulo>
    {
        public ModulosParentsSpec()
        {

        }

        public override string Description => $"";

        protected override Expression<Func<Modulo, bool>> GetFinalExpression() => x => x.Modulo_IdPai == 0;
    }
}
