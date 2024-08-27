namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
    public class MenuRequest : RequestBase, IRequest
    {
        [JsonPropertyName("name")]
        [JsonProperty(PropertyName = "name")]
        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value is not null)
                    _name = value.ToString().ToUpper();
            }
        }

        private string? _name;

        [JsonPropertyName("description")]
        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; } = null;

        [JsonPropertyName("is_active")]
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("icone")]
        [JsonProperty(PropertyName = "icone")]
        public String? Icone { get; set; }


        [JsonPropertyName("route")]
        [JsonProperty(PropertyName = "route")]
        public String? Route { get; set; }
    }
}
