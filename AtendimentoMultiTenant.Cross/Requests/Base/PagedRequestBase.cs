namespace AtendimentoMultiTenant.Cross.Requests.Base
{
    public class PagedRequestBase : RequestBase
    {
        public int PageSize { get; set; } = 25;
        public int PageNumber { get; set; } = 1;
    }
}
