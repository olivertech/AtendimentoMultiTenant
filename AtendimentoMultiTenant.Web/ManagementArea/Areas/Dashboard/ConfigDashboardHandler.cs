namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Dashboard
{
    public class ConfigDashboardHandler : HandlerBase, IConfigDashboardHandler
    {
        public ConfigDashboardHandler(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }
    }
}
