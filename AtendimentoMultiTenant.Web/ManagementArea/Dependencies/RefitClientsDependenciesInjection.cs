namespace AtendimentoMultiTenant.Web.ManagementArea.Dependencies
{
    public static class RefitClientsDependenciesInjection
    {
        public static IServiceCollection AddRefitClientsDependenciesInjection(this IServiceCollection services)
        {
            var baseUrl = SharedConfigurations.BackEndUrl;

            services.AddRefitClient<IContainerDbClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
            services.AddRefitClient<IFeatureClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
            services.AddRefitClient<ILogAccessClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
            services.AddRefitClient<ILoginClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
            services.AddRefitClient<IMenuClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
            services.AddRefitClient<IRoleClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
            services.AddRefitClient<IRoleMenuClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

            return services;
        }
    }
}
