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
            services.AddScoped<IConfigDashboardHandler, ConfigDashboardHandler>();
            services.AddScoped<ILogAccessHandler, LogAccessHandler>();
            services.AddScoped<IContainerDbDetailHandler, ContainerDbDetailHandler>();
            services.AddScoped<IMenuHandler, MenuHandler>();
            services.AddScoped<IMenuDetailHandler, MenuDetailHandler>();
            services.AddScoped<IFeatureHandler, FeatureHandler>();
            services.AddScoped<IRoleHandler, RoleHandler>();
            services.AddScoped<IRoleDetailHandler, RoleDetailHandler>();
            services.AddScoped<IRoleMenuHandler, RoleMenuHandler>();
            
            //Services injections
            services.AddScoped<IStorageService, StorageService>();

            //HttpClient helpers injections
            //services.AddScoped<IHttpClientLogAccessHelper, HttpClientLogAccessHelper>();

            return services;
        }
    }
}
