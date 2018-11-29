using System.CodeDom.Compiler;
using System.ServiceModel;
using ECommerce.Application.Messages;

namespace ECommerce.Application.Interfaces
{
	[GeneratedCode("Service Generator", "1.0")]
	[ServiceContract]
	public partial interface IAdminUser
	{
		[OperationContract]
		GetUserByIdResponse GetUserById (GetUserByIdRequest request);
		[OperationContract]
		DeleteUserByIdResponse DeleteUserById (DeleteUserByIdRequest request);
		[OperationContract]
		GetAllUsersResponse GetAllUsers (GetAllUsersRequest request);
		[OperationContract]
		InsertUserResponse InsertUser (InsertUserRequest request);
		[OperationContract]
		UpdateUserResponse UpdateUser (UpdateUserRequest request);
		[OperationContract]
		GetUserByLoginResponse GetUserByLogin (GetUserByLoginRequest request);
			
	}
}
