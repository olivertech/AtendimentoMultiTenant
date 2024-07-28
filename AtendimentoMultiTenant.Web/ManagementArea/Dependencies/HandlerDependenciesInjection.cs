namespace AtendimentoMultiTenant.Web.ManagementArea.Dependencies
{
    public static class HandlerDependenciesInjection
    {
        public static IServiceCollection AddHandlerDependenciesInjection(this IServiceCollection services)
        {
            //Handler injections
            services.AddScoped<ILoginHandler, LoginHandler>();
            services.AddScoped<IContainerDbHandler, ContainerDbHandler>();

            //Services injections
            services.AddScoped<IStorageService, StorageService>();

            return services;
        }
    }
}
