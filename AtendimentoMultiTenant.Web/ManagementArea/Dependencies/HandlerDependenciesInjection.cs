namespace AtendimentoMultiTenant.Web.ManagementArea.Dependencies
{
    public static class HandlerDependenciesInjection
    {
        public static IServiceCollection AddHandlerDependenciesInjection(this IServiceCollection services)
        {
            //Repositories injections
            services.AddScoped<ILoginHandler, LoginHandler>();
            services.AddScoped<IContainerDbHandler, ContainerDbHandler>();

            return services;
        }
    }
}
