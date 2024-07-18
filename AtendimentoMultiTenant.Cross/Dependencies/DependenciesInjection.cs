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
            services.AddScoped<IPortHelper, PortHelper>();

            //Validators injections
            services.AddScoped<IValidator<UserRequest>, UserRequestValidator>();
            services.AddScoped<IValidator<TenantRequest>, TenantRequestValidator>();
            services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
            services.AddScoped<IValidator<ContainerDbRequest>, ContainerDbRequestValidator>();
            services.AddScoped<IValidator<ConfigurationRequest>, ConfigurationRequestValidator>();

            return services;
        }
    }
}
