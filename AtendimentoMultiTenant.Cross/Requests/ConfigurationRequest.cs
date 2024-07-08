namespace AtendimentoMultiTenant.Cross.Requests
{
    public class ConfigurationRequest : RequestBase
    {
        [JsonPropertyName("client_name")]
        [JsonProperty(PropertyName = "client_name")]
        [StringLength(50, ErrorMessage = "Informe nome do cliente com até 50 caracteres.")]
        [DefaultValue("<NOMECLIENTE>")]
        [Required]
        public string? ClientName { get; set; } = null;

        [JsonPropertyName("container_db_name")]
        [JsonProperty(PropertyName = "container_db_name")]
        [StringLength(250, ErrorMessage = "Informe nome do container com até 250 caracteres.")]
        [DefaultValue("<NOMECLIENTE>_postgresql")]
        [Required]
        public string? ContainerDbName { get; set; } = null;

        [JsonPropertyName("environment_db_name")]
        [JsonProperty(PropertyName = "environment_db_name")]
        [StringLength(250, ErrorMessage = "Informe nome do banco de dados com até 250 caracteres.")]
        [DefaultValue("<NOMECLIENTE>_db")]
        [Required]
        public string? EnvironmentDbName { get; set; }

        [JsonPropertyName("environment_db_user")]
        [JsonProperty(PropertyName = "environment_db_user")]
        [StringLength(50, ErrorMessage = "Informe nome do usuário do banco com até 50 caracteres.")]
        [DefaultValue("<NOMECLIENTE>_user_db")]
        [Required]
        public string? EnvironmentDbUser { get; set; }

        [JsonPropertyName("environment_db_pwd")]
        [JsonProperty(PropertyName = "environment_db_pwd")]
        [StringLength(50, ErrorMessage = "Informe senha do usuário do banco com até 50 caracteres.")]
        [DefaultValue("!<NOMECLIENTE>@<ANO4DIGITOS><MES2DIGITOS><DIA2DIGITOS>#")]
        [Required]
        public string? EnvironmentDbPwd { get; set; }

        [JsonPropertyName("container_db_volume")]
        [JsonProperty(PropertyName = "container_db_volume")]
        [StringLength(50, ErrorMessage = "Informe nome do volume do container com até 50 caracteres.")]
        [DefaultValue("<NOMECLIENTE>_volume")]
        [Required]
        public string? ContainerDbVolume { get; set; }

        [JsonPropertyName("container_db_network")]
        [JsonProperty(PropertyName = "container_db_network")]
        [StringLength(50, ErrorMessage = "Informe nome da rede do container com até 50 caracteres.")]
        [DefaultValue("<NOMECLIENTE>_network")]
        [Required]
        public string? ContainerDbNetwork { get; set; }
    }
}
