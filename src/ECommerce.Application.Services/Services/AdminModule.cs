using System;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Messages;
using ECommerce.Domain.Core;
using ECommerce.Domain.Factories;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Context.ServiceContext;
using ECommerce.Infrastructure.Factories;
using ECommerce.Infrastructure.Mapper;
using ECommerce.Infrastructure.Repositories.Relational;
using Framework.Domain.Core;
using P2A.Leads.Domain.Specifications;

namespace ECommerce.Application.Services
{
	public class AdminModule : AdminModuleBase
	{
        protected readonly IMapperService _mapperService = ServiceContext<MapperService>.GetServiceContext();
        protected readonly IModuloRepository _moduloRepository = ServiceContext<ModuloRepository>.GetServiceContext();
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IModuloFactory _moduloFactory = ServiceContext<ModuloFactory>.GetServiceContext();

        #region Constructor
        public AdminModule()
		{
            _mapperService = _mapperService ?? ServiceContext<MapperService>.Store(new MapperService());
            _moduloRepository = _moduloRepository ?? ServiceContext<ModuloRepository>.Store(new ModuloRepository());
            _unitOfWork = new UnitOfWork();

            _moduloFactory= _moduloFactory ?? ServiceContext<ModuloFactory>.Store(new ModuloFactory());
        }
		#endregion
		
		#region Operation Methods Implementation
		public override GetModulesByUserIdResponse OnGetModulesByUserIdExecute(GetModulesByUserIdRequest request)
        {
            GetModulesByUserIdResponse response = new GetModulesByUserIdResponse();

            try
            {
                var parentsSpec = new ModulosParentsSpec();
                var parentsModules = _moduloRepository.Query(parentsSpec);

                var spec = new ModulosByUserIdSpec(request.Id);
                var modulesByUser = _moduloRepository.GetModulosByUserId(spec);

                response.Modulos  = _moduloFactory.CreateListModules(parentsModules, modulesByUser);
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
