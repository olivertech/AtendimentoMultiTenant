﻿namespace AtendimentoMultiTenant.Shared.Requests.Base
{
    public class PagedRequestBase
    {
        [JsonPropertyName("page_size")]
        [JsonProperty(PropertyName = "page_size")]
        [DefaultValue(CoreConfigurations.PAGESIZE)]
        public int PageSize { get; set; } = CoreConfigurations.PAGESIZE;

        [JsonPropertyName("page_number")]
        [JsonProperty(PropertyName = "page_number")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
    }
}
