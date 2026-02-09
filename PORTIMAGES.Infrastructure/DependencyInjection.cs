using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PORTIMAGES.Application.Admin.Interfaces;
using PORTIMAGES.Application.Auth.AuthEmployee.Interfaces;
using PORTIMAGES.Application.Auth.AuthUser.Interfaces;
using PORTIMAGES.Application.Common.Interfaces;
using PORTIMAGES.Application.Ship.Interfaces;
using PORTIMAGES.Infrastructure.Common.Repositories;
using PORTIMAGES.Infrastructure.Persistence;
using PORTIMAGES.Infrastructure.Repositories.Admin;
using PORTIMAGES.Infrastructure.Repositories.Auth.AuthEmployee;
using PORTIMAGES.Infrastructure.Repositories.Auth.AuthUser;
namespace PORTIMAGES.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddScoped<IDapperRepository, DapperRepository>(); 
            services.AddScoped<IEmployeeRepository, EmployeeRepository>(); 
            services.AddScoped<IUserRepository, UserRepository>(); 
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IMenuRepository,MenuRepository>();
            services.AddScoped<ITerminalRepository,TerminalRepository>();
            services.AddScoped<IInventoryStatusRepository, InventoryStatusRepository>();
            services.AddScoped<IUserMasterRepository, UserMasterRepository>();
            services.AddScoped<IEmployeeMasterRepository, EmployeeMasterRepository>();
            services.AddScoped<IVehicleStatusRepository, VehicleStatusRepository>();
            services.AddScoped<IINSDestinationRepository, INSDestinationRepository>();
            services.AddScoped<IINSStatusRepository, INSStatusRepository>();
            services.AddScoped<IINSOrganizationRepository, INSOrganizationRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDropdownRepository, DropdownRepository>();
            services.AddScoped<IShipRepository, ShipRepository>();
            services.AddScoped<IShipTypeRepository, ShipTypeRepository>();
            services.AddScoped<IShipUseRepository, ShipUseRepository>();
            services.AddScoped<IPortRepository, PortRepository>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
