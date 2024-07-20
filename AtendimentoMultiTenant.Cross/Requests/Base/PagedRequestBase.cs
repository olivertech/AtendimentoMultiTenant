using AtendimentoMultiTenant.Cross.Classes;

namespace AtendimentoMultiTenant.Cross.Requests.Base
{
    public class PagedRequestBase
    {
        [JsonPropertyName("page_size")]
        [JsonProperty(PropertyName = "page_size")]
        [DefaultValue(Configurations.PAGESIZE)]
        public int PageSize { get; set; } = Configurations.PAGESIZE;

        [JsonPropertyName("page_number")]
        [JsonProperty(PropertyName = "page_number")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
    }
}
