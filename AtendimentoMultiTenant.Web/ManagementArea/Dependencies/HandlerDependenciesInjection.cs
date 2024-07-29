namespace AtendimentoMultiTenant.Web.ManagementArea.Dependencies
{
    public static class HandlerDependenciesInjection
    {
        public static IServiceCollection AddHandlerDependenciesInjection(this IServiceCollection services)
        {
            //Layouts Handler Injections
            services.AddScoped<IMainLayoutHandler, MainLayoutHandler>();
            services.AddScoped<IConfigDashboardMainLayoutHandler, ConfigDashboardMainLayoutHandler>();

            //Pages Handler Injections
            services.AddScoped<ILoginHandler, LoginHandler>();
            services.AddScoped<IContainerDbHandler, ContainerDbHandler>();
            services.AddScoped<ITicketListHandler, TicketListHandler>();
            services.AddScoped<IConfigDashboardHandler, ConfigDashboardHandler>();

            //Services injections
            services.AddScoped<IStorageService, StorageService>();

            return services;
        }
    }
}
