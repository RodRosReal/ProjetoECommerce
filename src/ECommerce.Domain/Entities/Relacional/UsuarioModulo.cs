//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECommerce.Domain.Entities.Relacional
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsuarioModulo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ModuloId { get; set; }
    
        public virtual Modulo Modulo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}