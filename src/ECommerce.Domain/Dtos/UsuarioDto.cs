using ECommerce.Domain.Core;
using System;

namespace ECommerce.Domain.Dtos
{
    public class UsuarioDto : IDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public Nullable<bool> Disponivel { get; set; }
        public Nullable<System.DateTime> UltimoAcesso { get; set; }
        public Nullable<bool> NotificacaoPedido { get; set; }
        public Nullable<bool> NotificacaoFaleConosco { get; set; }
        public Nullable<bool> NotificacaoAviseMe { get; set; }
        public Nullable<bool> NotificacaoCotacao { get; set; }
        public Nullable<bool> NotificacaoTrabalheConosco { get; set; }
    }
}
