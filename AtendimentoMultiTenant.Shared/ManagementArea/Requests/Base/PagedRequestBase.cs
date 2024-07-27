namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base
{
    public class PagedRequestBase
    {
        [JsonPropertyName("page_size")]
        [JsonProperty(PropertyName = "page_size")]
        [DefaultValue(SharedConfigurations.PageSize)]
        public int PageSize { get; set; } = SharedConfigurations.PageSize;

        [JsonPropertyName("page_number")]
        [JsonProperty(PropertyName = "page_number")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
    }
}
