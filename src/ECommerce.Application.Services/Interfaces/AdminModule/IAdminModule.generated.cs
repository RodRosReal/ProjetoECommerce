using System.CodeDom.Compiler;
using System.ServiceModel;
using ECommerce.Application.Messages;

namespace ECommerce.Application.Interfaces
{
	[GeneratedCode("Service Generator", "1.0")]
	[ServiceContract]
	public partial interface IAdminModule
	{
		[OperationContract]
		GetModulesByUserIdResponse GetModulesByUserId (GetModulesByUserIdRequest request);
			
	}
}
