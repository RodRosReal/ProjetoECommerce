using System;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Messages;

namespace ECommerce.Application.Services
{
	public abstract partial class AdminUserBase : IAdminUser
	{
		#region Constructor
		protected AdminUserBase()
		{
				
			GetUserByIdInitialization += OnAdminUserInitialization;
        	GetUserByIdExecute += OnGetUserByIdExecute;
        	GetUserByIdComplete += OnAdminUserComplete;
        	GetUserByIdError += OnAdminUserError;
				
			DeleteUserByIdInitialization += OnAdminUserInitialization;
        	DeleteUserByIdExecute += OnDeleteUserByIdExecute;
        	DeleteUserByIdComplete += OnAdminUserComplete;
        	DeleteUserByIdError += OnAdminUserError;
				
			GetAllUsersInitialization += OnAdminUserInitialization;
        	GetAllUsersExecute += OnGetAllUsersExecute;
        	GetAllUsersComplete += OnAdminUserComplete;
        	GetAllUsersError += OnAdminUserError;
				
			InsertUserInitialization += OnAdminUserInitialization;
        	InsertUserExecute += OnInsertUserExecute;
        	InsertUserComplete += OnAdminUserComplete;
        	InsertUserError += OnAdminUserError;
				
			UpdateUserInitialization += OnAdminUserInitialization;
        	UpdateUserExecute += OnUpdateUserExecute;
        	UpdateUserComplete += OnAdminUserComplete;
        	UpdateUserError += OnAdminUserError;
				
			GetUserByLoginInitialization += OnAdminUserInitialization;
        	GetUserByLoginExecute += OnGetUserByLoginExecute;
        	GetUserByLoginComplete += OnAdminUserComplete;
        	GetUserByLoginError += OnAdminUserError;
				
		}
		#endregion
		
		#region Operation Events
		
		public event Action< GetUserByIdRequest, GetUserByIdResponse> GetUserByIdInitialization;
		public event Func< GetUserByIdRequest, GetUserByIdResponse> GetUserByIdExecute;
		public event Action< GetUserByIdRequest, GetUserByIdResponse> GetUserByIdComplete;
		public event Action< GetUserByIdRequest, GetUserByIdResponse, Exception> GetUserByIdError;
		
		public event Action< DeleteUserByIdRequest, DeleteUserByIdResponse> DeleteUserByIdInitialization;
		public event Func< DeleteUserByIdRequest, DeleteUserByIdResponse> DeleteUserByIdExecute;
		public event Action< DeleteUserByIdRequest, DeleteUserByIdResponse> DeleteUserByIdComplete;
		public event Action< DeleteUserByIdRequest, DeleteUserByIdResponse, Exception> DeleteUserByIdError;
		
		public event Action< GetAllUsersRequest, GetAllUsersResponse> GetAllUsersInitialization;
		public event Func< GetAllUsersRequest, GetAllUsersResponse> GetAllUsersExecute;
		public event Action< GetAllUsersRequest, GetAllUsersResponse> GetAllUsersComplete;
		public event Action< GetAllUsersRequest, GetAllUsersResponse, Exception> GetAllUsersError;
		
		public event Action< InsertUserRequest, InsertUserResponse> InsertUserInitialization;
		public event Func< InsertUserRequest, InsertUserResponse> InsertUserExecute;
		public event Action< InsertUserRequest, InsertUserResponse> InsertUserComplete;
		public event Action< InsertUserRequest, InsertUserResponse, Exception> InsertUserError;
		
		public event Action< UpdateUserRequest, UpdateUserResponse> UpdateUserInitialization;
		public event Func< UpdateUserRequest, UpdateUserResponse> UpdateUserExecute;
		public event Action< UpdateUserRequest, UpdateUserResponse> UpdateUserComplete;
		public event Action< UpdateUserRequest, UpdateUserResponse, Exception> UpdateUserError;
		
		public event Action< GetUserByLoginRequest, GetUserByLoginResponse> GetUserByLoginInitialization;
		public event Func< GetUserByLoginRequest, GetUserByLoginResponse> GetUserByLoginExecute;
		public event Action< GetUserByLoginRequest, GetUserByLoginResponse> GetUserByLoginComplete;
		public event Action< GetUserByLoginRequest, GetUserByLoginResponse, Exception> GetUserByLoginError;
		#endregion
		
		#region Abstract Service Methods
		public virtual void OnAdminUserInitialization(AdminUserRequest request, AdminUserResponse response) {}
      	public virtual void OnAdminUserComplete(AdminUserRequest request, AdminUserResponse response) {}
        public virtual void OnAdminUserError(AdminUserRequest request, AdminUserResponse response, Exception exception) { throw exception; }
		#endregion
		
		#region Abstract Operation Methods
				
		public abstract GetUserByIdResponse OnGetUserByIdExecute(GetUserByIdRequest request);
				
		public abstract DeleteUserByIdResponse OnDeleteUserByIdExecute(DeleteUserByIdRequest request);
				
		public abstract GetAllUsersResponse OnGetAllUsersExecute(GetAllUsersRequest request);
				
		public abstract InsertUserResponse OnInsertUserExecute(InsertUserRequest request);
				
		public abstract UpdateUserResponse OnUpdateUserExecute(UpdateUserRequest request);
				
		public abstract GetUserByLoginResponse OnGetUserByLoginExecute(GetUserByLoginRequest request);
		#endregion
		
		#region Operation Implementations
				
		public virtual GetUserByIdResponse GetUserById(GetUserByIdRequest request) {
			var response = new GetUserByIdResponse();
			try {
				// Raise Initialization Event
				var initialization = GetUserByIdInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetUserByIdExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetUserByIdComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetUserByIdError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual DeleteUserByIdResponse DeleteUserById(DeleteUserByIdRequest request) {
			var response = new DeleteUserByIdResponse();
			try {
				// Raise Initialization Event
				var initialization = DeleteUserByIdInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = DeleteUserByIdExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = DeleteUserByIdComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = DeleteUserByIdError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual GetAllUsersResponse GetAllUsers(GetAllUsersRequest request) {
			var response = new GetAllUsersResponse();
			try {
				// Raise Initialization Event
				var initialization = GetAllUsersInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetAllUsersExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetAllUsersComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetAllUsersError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual InsertUserResponse InsertUser(InsertUserRequest request) {
			var response = new InsertUserResponse();
			try {
				// Raise Initialization Event
				var initialization = InsertUserInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = InsertUserExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = InsertUserComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = InsertUserError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual UpdateUserResponse UpdateUser(UpdateUserRequest request) {
			var response = new UpdateUserResponse();
			try {
				// Raise Initialization Event
				var initialization = UpdateUserInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = UpdateUserExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = UpdateUserComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = UpdateUserError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual GetUserByLoginResponse GetUserByLogin(GetUserByLoginRequest request) {
			var response = new GetUserByLoginResponse();
			try {
				// Raise Initialization Event
				var initialization = GetUserByLoginInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetUserByLoginExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetUserByLoginComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetUserByLoginError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				#endregion
	}
}
