namespace AtendimentoMultiTenant.Infra.ManagementArea.Dependencies
{
    /// <summary>
    /// Classe estática que concentra as configurações
    /// da conexão com os banco de dados e registros 
    /// de injeções de dependência
    /// </summary>
    public static class RepositoryDependenciesInjection
    {
        public static IServiceCollection AddRepositoryDependenciesInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //PostGreSql Database Configuration
            services.AddDbContext<ManagementAreaDbContext>(options =>
                                                options.UseNpgsql(
                                                    configuration.GetConnectionString("ConfigConnection"))
                                                );

            //Repositories injections
            services.AddScoped<IContainerDbRepository, ContainerDbRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IPortRepository, PortRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IUserFeatureRepository, UserFeatureRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPortFinder, PortFinderHelper>();

            return services;
        }
    }
}
