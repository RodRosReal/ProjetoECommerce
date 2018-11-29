using ECommerce.Domain.Core;
using ECommerce.Domain.Dtos;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace ECommerce.Application.Messages
{
	[DataContract]
	public partial class GetAllUsersResponse 
	{
        [DataMember]
        public PagedResult<UsuarioDto> PageResult { get; set; }
    } 
}
