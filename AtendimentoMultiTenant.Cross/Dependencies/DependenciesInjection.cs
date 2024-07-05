﻿using AtendimentoMultiTenant.Core.Interfaces;
using AtendimentoMultiTenant.Cross.Helpers;
using AtendimentoMultiTenant.Cross.Interfaces;
using AtendimentoMultiTenant.Infra.Repositories;

namespace AtendimentoMultiTenant.Cross.Dependencies
{
    /// <summary>
    /// Classe estática que concentra as configurações
    /// da conexão com os banco de dados e registros 
    /// de injeções de dependência
    /// </summary>
    public static class DependenciesInjection
    {
        public static IServiceCollection AddDependenciesInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //PostGreSql Database Configuration
            services.AddDbContext<AppDbContext>(options =>
                                                options.UseNpgsql(
                                                    configuration.GetConnectionString("ConfigConnection"))
                                                );

            //Repository injections
            services.AddScoped<IContainerRepository, ContainerRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPortRepository, PortRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPortHelper, PortHelper>();

            return services;
        }
    }
}