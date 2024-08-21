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
            services.AddScoped<IConfigDashboardHandler, ConfigDashboardHandler>();
            services.AddScoped<ILeftMenuHandler, LeftMenuHandler>();
            services.AddScoped<ILogAccessHandler, LogAccessHandler>();
            services.AddScoped<IContainerDbDetailHandler, ContainerDbDetailHandler>();
            services.AddScoped<IMenuHandler, MenuHandler>();

            //Services injections
            services.AddScoped<IStorageService, StorageService>();

            //HttpClient helpers injections
            //services.AddScoped<IHttpClientLogAccessHelper, HttpClientLogAccessHelper>();

            return services;
        }
    }
}
