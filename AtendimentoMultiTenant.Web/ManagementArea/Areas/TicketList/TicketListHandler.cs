namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.TicketList
{
    public class TicketListHandler : HandlerBase, ITicketListHandler
    {
        /// <summary>
        /// TODO: PESQUISAR SOBRE RETRY PATTERN / BIBLIOTECA POLLY
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public TicketListHandler(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }
    }
}
