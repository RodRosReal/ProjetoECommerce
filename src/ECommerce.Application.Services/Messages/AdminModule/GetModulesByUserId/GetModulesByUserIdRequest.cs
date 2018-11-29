using System.Runtime.Serialization;
namespace ECommerce.Application.Messages
{
	[DataContract]
	public partial class GetModulesByUserIdRequest 
	{
        [DataMember]
        public int Id { get; set; }
    } 
}
