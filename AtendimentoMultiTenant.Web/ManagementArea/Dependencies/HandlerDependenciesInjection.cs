namespace AtendimentoMultiTenant.Web.ManagementArea.Dependencies
{
    public static class HandlerDependenciesInjection
    {
        public static IServiceCollection AddHandlerDependenciesInjection(this IServiceCollection services)
        {
            //Layouts Handler Injections
            services.AddScoped<IMainLayoutHandler, MainLayoutHandler>();
            services.AddScoped<IConfigDashboardMainLayoutHandler, ConfigDashboardMainLayoutHandler>();
          
            //Services injections
            services.AddScoped<IStorageService, StorageService>();

            //HttpClient helpers injections
            //services.AddScoped<IHttpClientLogAccessHelper, HttpClientLogAccessHelper>();

            return services;
        }
    }
}
