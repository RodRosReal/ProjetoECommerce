using ECommerce.Application.Messages;
using ECommerce.Domain.Core;
using ECommerce.Domain.Dtos;
using ECommerce.Domain.Entities.Relacional;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Context.ServiceContext;
using ECommerce.Infrastructure.Mapper;
using ECommerce.Infrastructure.Repositories.Relational;
using Framework.Domain.Core;
using P2A.Leads.Domain.Specifications;
using System;
using System.Collections.Generic;

namespace ECommerce.Application.Services
{
    public class AdminUser : AdminUserBase
    {
        protected readonly IMapperService _mapperService = ServiceContext<MapperService>.GetServiceContext();
        protected readonly IUsuarioRepository _usuarioRepository = ServiceContext<UsuarioRepository>.GetServiceContext();
        protected readonly IUnitOfWork _unitOfWork;

        #region Constructor
        public AdminUser()
        {
            _mapperService = _mapperService ?? ServiceContext<MapperService>.Store(new MapperService());
            _usuarioRepository = _usuarioRepository ?? ServiceContext<UsuarioRepository>.Store(new UsuarioRepository());
            _unitOfWork = new UnitOfWork();
        }
        #endregion

        #region Operation Methods Implementation
        public override GetUserByIdResponse OnGetUserByIdExecute(GetUserByIdRequest request)
        {
            GetUserByIdResponse response = new GetUserByIdResponse();

            try
            {
                var spec = new UsuarioByIdSpec(request.Id);
                var repository = _usuarioRepository.Get(spec);

                response.Usuario = _mapperService.Map<UsuarioDto>(repository);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            return response;
        }

        public override DeleteUserByIdResponse OnDeleteUserByIdExecute(DeleteUserByIdRequest request)
        {
            DeleteUserByIdResponse response = new DeleteUserByIdResponse();

            try
            {
                var spec = new UsuarioByIdSpec(request.Id);
                var user = _usuarioRepository.Get(spec);

                _usuarioRepository.Delete(user);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            return response;
        }

        public override GetAllUsersResponse OnGetAllUsersExecute(GetAllUsersRequest request)
        {
            GetAllUsersResponse response = new GetAllUsersResponse();

            try
            {
                if (request != null)
                {
                    var spec = new UsuariosAllSpec(request.Filter);

                    if (request.PageSize > 0)
                    {
                        var pagedOptions = new PagedOptions() { Direction = request.SortDirection, OrderBy = request.PropertyName, PageNumber = request.PageNumber, PageSize = request.PageSize, IncludeTotalCount = true };

                        var repository = _usuarioRepository.QueryPaged(pagedOptions, spec);

                        response.PageResult = new PagedResult<UsuarioDto>(repository.PageNumber, repository.PageSize, repository.TotalCount, _mapperService.Map<List<UsuarioDto>>(repository.DataList));
                    }
                    else
                    {
                        var repository = _usuarioRepository.Query(spec, request.PropertyName, request.SortDirection);

                        response.PageResult = new PagedResult<UsuarioDto>(0, 0, repository.Count, _mapperService.Map<List<UsuarioDto>>(repository));
                    }
                }
                else
                {
                    var usuarios = _usuarioRepository.Query(null);
                    response.PageResult = new PagedResult<UsuarioDto>(0, 0, usuarios.Count, _mapperService.Map<List<UsuarioDto>>(usuarios));
                }

            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            return response;
        }

        public override InsertUserResponse OnInsertUserExecute(InsertUserRequest request)
        {
            InsertUserResponse response = new InsertUserResponse();

            try
            {
                var user = _mapperService.Map<Usuario>(request.Usuario);

                _usuarioRepository.Insert(user);
                _unitOfWork.Commit();

                response.Usuario = _mapperService.Map<UsuarioDto>(user);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            return response;
        }

        public override UpdateUserResponse OnUpdateUserExecute(UpdateUserRequest request)
        {
            UpdateUserResponse response = new UpdateUserResponse();

            try
            {
                var spec = new UsuarioByIdSpec(request.Usuario.Id);
                var user = _usuarioRepository.Get(spec);

                user = _mapperService.Map<Usuario>(request.Usuario);

                _usuarioRepository.Update(user);
                _unitOfWork.Commit();

                response.Usuario = _mapperService.Map<UsuarioDto>(user);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            return response;
        }

        public override GetUserByLoginResponse OnGetUserByLoginExecute(GetUserByLoginRequest request)
        {
            GetUserByLoginResponse response = new GetUserByLoginResponse();

            try
            {
                var spec = new UsuarioByLoginSpec(request.Login);
                var user = _usuarioRepository.Get(spec);

                response.Usuario = _mapperService.Map<UsuarioDto>(user);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            return response;
        }

        #endregion
    }
}
