using System;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Messages;

namespace ECommerce.Application.Services
{
	public abstract partial class AdminModuleBase : IAdminModule
	{
		#region Constructor
		protected AdminModuleBase()
		{
				
			GetModulesByUserIdInitialization += OnAdminModuleInitialization;
        	GetModulesByUserIdExecute += OnGetModulesByUserIdExecute;
        	GetModulesByUserIdComplete += OnAdminModuleComplete;
        	GetModulesByUserIdError += OnAdminModuleError;
				
		}
		#endregion
		
		#region Operation Events
		
		public event Action< GetModulesByUserIdRequest, GetModulesByUserIdResponse> GetModulesByUserIdInitialization;
		public event Func< GetModulesByUserIdRequest, GetModulesByUserIdResponse> GetModulesByUserIdExecute;
		public event Action< GetModulesByUserIdRequest, GetModulesByUserIdResponse> GetModulesByUserIdComplete;
		public event Action< GetModulesByUserIdRequest, GetModulesByUserIdResponse, Exception> GetModulesByUserIdError;
		#endregion
		
		#region Abstract Service Methods
		public virtual void OnAdminModuleInitialization(AdminModuleRequest request, AdminModuleResponse response) {}
      	public virtual void OnAdminModuleComplete(AdminModuleRequest request, AdminModuleResponse response) {}
        public virtual void OnAdminModuleError(AdminModuleRequest request, AdminModuleResponse response, Exception exception) { throw exception; }
		#endregion
		
		#region Abstract Operation Methods
				
		public abstract GetModulesByUserIdResponse OnGetModulesByUserIdExecute(GetModulesByUserIdRequest request);
		#endregion
		
		#region Operation Implementations
				
		public virtual GetModulesByUserIdResponse GetModulesByUserId(GetModulesByUserIdRequest request) {
			var response = new GetModulesByUserIdResponse();
			try {
				// Raise Initialization Event
				var initialization = GetModulesByUserIdInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetModulesByUserIdExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetModulesByUserIdComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetModulesByUserIdError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				#endregion
	}
}
