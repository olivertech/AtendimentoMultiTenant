namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses.Base
{
    public class ResponsePagedBase
    {
        /// <summary>
        /// Receipted parameter
        /// </summary>
        [JsonProperty(PropertyName = "page_number")]
        public int PageNumber { get; set; }

        /// <summary>
        /// Receipted parameter
        /// </summary>
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }

        /// <summary>
        /// Calculated parameter
        /// </summary>
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        /// <summary>
        /// Parametrized parameter
        /// </summary>
        [JsonProperty(PropertyName = "page_size")]
        public int PageSize { get; set; } = SharedConfigurations.PageSize; //Fixo e Parametrizado
    }
}
