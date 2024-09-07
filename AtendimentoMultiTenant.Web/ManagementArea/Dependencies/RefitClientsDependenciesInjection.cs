using AtendimentoMultiTenant.Web.RefitClients;
using Refit;

namespace AtendimentoMultiTenant.Web.ManagementArea.Dependencies
{
    public static class RefitClientsDependenciesInjection
    {
        public static IServiceCollection AddRefitClientsDependenciesInjection(this IServiceCollection services)
        {
            var baseUrl = "https://localhost:7300";

            services.AddRefitClient<ILoginClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
            services.AddRefitClient<IMenuClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
            services.AddRefitClient<IContainerDbClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

            return services;
        }
    }
}
