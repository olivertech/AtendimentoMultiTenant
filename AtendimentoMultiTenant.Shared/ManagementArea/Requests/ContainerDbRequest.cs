namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
    public class ContainerDbRequest : RequestBase, IRequest
    {
        [JsonPropertyName("container_name")]
        [JsonProperty(PropertyName = "container_name")]
        [NameCustomValidator(ErrorMessage = "Informe apenas letras, números e '_', sem espaço em branco.")]
        public string? ContainerDbName { get; set; } = null;

        [JsonPropertyName("environment_db_name")]
        [JsonProperty(PropertyName = "environment_db_name")]
        [NameCustomValidator(ErrorMessage = "Informe apenas letras, números e '_', sem espaço em branco.")]
        public string? EnvironmentDbName { get; set; }

        [JsonPropertyName("environment_db_user")]
        [JsonProperty(PropertyName = "environment_db_user")]
        [NameCustomValidator(ErrorMessage = "Informe apenas letras, números e '_', sem espaço em branco.")]
        public string? EnvironmentDbUser { get; set; }

        [JsonPropertyName("environment_db_pwd")]
        [JsonProperty(PropertyName = "environment_db_pwd")]
        [PwdCustomValidator(ErrorMessage = "Informe apenas letras, números e '_@#', sem espaço em branco.")]
        public string? EnvironmentDbPwd { get; set; }

        [JsonPropertyName("container_volume")]
        [JsonProperty(PropertyName = "container_volume")]
        [NameCustomValidator(ErrorMessage = "Informe apenas letras, números e '_', sem espaço em branco.")]
        public string? ContainerDbVolume { get; set; }

        [JsonPropertyName("container_network")]
        [JsonProperty(PropertyName = "container_network")]
        [NameCustomValidator(ErrorMessage = "Informe apenas letras, números e '_', sem espaço em branco.")]
        public string? ContainerDbNetwork { get; set; }

        [JsonPropertyName("is_up")]
        [JsonProperty(PropertyName = "is_up")]
        public bool IsUp { get; set; } = false;

        [JsonPropertyName("is_active")]
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }
    }
}
