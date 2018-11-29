using System.Runtime.Serialization;
namespace ECommerce.Application.Messages
{
	[DataContract]
	public partial class DeleteUserByIdRequest 
	{
        [DataMember]
        public int Id { get; set; }
    } 
}
