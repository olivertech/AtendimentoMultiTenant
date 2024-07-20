namespace AtendimentoMultiTenant.Cross.Responses.Base
{
    public class ResponsePagedBase
    {
        [JsonProperty(PropertyName = "current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        [JsonProperty(PropertyName = "page_size")]
        public int PageSize{ get; set; } = Configurations.PAGESIZE;

        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }
    }
}
