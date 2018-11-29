using System.Runtime.Serialization;
namespace ECommerce.Application.Messages
{
	[DataContract]
	public partial class GetUserByLoginRequest 
	{
        [DataMember]
        public string Login { get; set; }
    } 
}
