using ECommerce.Domain.Dtos;
using System.Runtime.Serialization;
namespace ECommerce.Application.Messages
{
	[DataContract]
	public partial class InsertUserRequest 
	{
        [DataMember]
        public UsuarioDto Usuario { get; set; }
    } 
}
