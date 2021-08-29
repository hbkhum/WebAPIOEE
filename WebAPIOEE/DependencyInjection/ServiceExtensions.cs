using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebAPIOEE.Infrastructure.Interfaces;
using WebAPIOEE.Repositories;
using WebAPIOEE.Services;
using WebAPIOEE.Services.Interfaces;

namespace WebAPIOEE.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterRepositories(
            this IServiceCollection repositories)
        {


            repositories.TryAddTransient<IEquipmentRepository, EquipmentRepository>();
            repositories.TryAddTransient<IEquipmentResultRepository, EquipmentResultRepository>();
            repositories.TryAddTransient<IEquipmentTypeRepository, EquipmentTypeRepository>();
            repositories.TryAddTransient<ILineRepository, LineRepository>();
            repositories.TryAddTransient<IMatrixRepository, MatrixRepository>();
            // Add all other services here.
            return repositories;
        }

        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {


            services.TryAddTransient<IEquipmentService, EquipmentService>();
            services.TryAddTransient<IEquipmentResultService, EquipmentResultService>();
            services.TryAddTransient<IEquipmentTypeService, EquipmentTypeService>();
            services.TryAddTransient<ILineService, LineService>();
            services.TryAddTransient<IMatrixService, MatrixService>();


            //services.TryAddTransient<IStationGroupService, StationGroupService>();

            // Add all other services here.
            return services;
        }

        public static IServiceCollection RegisterDataServices(
            this IServiceCollection services)
        {
            services.TryAddTransient<IDataServices, DataServices>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Add all other services here.
            return services;
        }

        public static IServiceCollection RegisterDataRepositories(
            this IServiceCollection services)
        {
            services.TryAddTransient<IDataRepositories, DataRepositories>();

            // Add all other services here.
            return services;
        }
    }
}
