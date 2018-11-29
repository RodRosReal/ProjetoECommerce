using ECommerce.Domain.Core;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Dtos
{
    public class ModuloDto : IDto
    {
        public int Id { get; set; }
        public int ModuloIdPai { get; set; }
        public string Nome { get; set; }
        public string Link { get; set; }
        public int Ordem { get; set; }

        public List<ModuloDto> SubModulos { get; set; }
    }
}
