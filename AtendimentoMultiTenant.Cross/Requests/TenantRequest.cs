namespace AtendimentoMultiTenant.Cross.Requests
{
    public class TenantRequest : RequestBase
    {
        [JsonPropertyName("name")]
        [JsonProperty(PropertyName = "name")]
        [StringLength(250, ErrorMessage = "Informe nome do usuário com até 50 caracteres.")]
        [Required]
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

        [JsonPropertyName("secret")]
        [JsonProperty(PropertyName = "secret")]
        public string? Secret { get; set; } = null;

        [JsonPropertyName("connection_string")]
        [JsonProperty(PropertyName = "connection_string")]
        [Required]
        public string? ConnectionString { get; set; } = null;

        [JsonPropertyName("id")]
        [JsonProperty(PropertyName = "id")]
        public string? InitialUrl { get; set; } = null;

        [JsonPropertyName("id")]
        [JsonProperty(PropertyName = "id")]
        public bool IsActive { get; set; } = true;
    }
}
