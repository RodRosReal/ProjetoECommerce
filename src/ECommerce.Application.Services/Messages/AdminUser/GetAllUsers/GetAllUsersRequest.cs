using ECommerce.Domain.Dtos;
using ECommerce.Domain.ValueObjects;
using System.Runtime.Serialization;
namespace ECommerce.Application.Messages
{
	[DataContract]
	public partial class GetAllUsersRequest 
	{
        [DataMember]
        public UsuarioFilter Filter { get; set; }

        [DataMember]
        public int PageNumber { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public string PropertyName { get; set; }

        [DataMember]
        public SortDirection SortDirection { get; set; }
    } 
}
