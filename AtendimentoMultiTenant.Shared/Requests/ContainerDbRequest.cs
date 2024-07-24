namespace AtendimentoMultiTenant.Shared.Requests
{
    public class ContainerDbRequest : RequestBase, IRequest
    {
        [JsonPropertyName("client_name")]
        [JsonProperty(PropertyName = "client_name")]
        [NameCustomValidator(ErrorMessage = "Informe apenas letras, números e '_', sem espaço em branco.")]
        public string? ClientName
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
    }
}
