using ECommerce.Domain.Dtos;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace ECommerce.Application.Messages
{
	[DataContract]
	public partial class GetModulesByUserIdResponse 
	{
        [DataMember]
        public List<ModuloDto> Modulos { get; set; }
    } 
}
