namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public class MenuResponse : IResponse
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; } = null;

        [JsonProperty(PropertyName = "icone")]
        public string? Icone { get; set; } = null;

        [JsonProperty(PropertyName = "route")]
        public string? Route { get; set; } = null;

        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; } = null;

        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }
    }
}
