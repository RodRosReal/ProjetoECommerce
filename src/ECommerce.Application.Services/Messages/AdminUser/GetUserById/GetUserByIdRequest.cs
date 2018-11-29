using System.Runtime.Serialization;
namespace ECommerce.Application.Messages
{
	[DataContract]
	public partial class GetUserByIdRequest 
	{
        [DataMember]
        public int Id { get; set; }
    } 
}
