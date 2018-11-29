using ECommerce.Domain.Core;
using Framework.Domain.Core;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Dtos
{
    public class UsuarioFilter
    {
        public string NomeLike { get; set; }
        public string LoginLike { get; set; }
        public string EmailLike { get; set; }
    }
}
