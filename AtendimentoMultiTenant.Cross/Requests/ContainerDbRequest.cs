namespace AtendimentoMultiTenant.Cross.Requests
{
    public class ContainerDbRequest : RequestBase
    {
        [JsonPropertyName("container_name")]
        [JsonProperty(PropertyName = "container_name")]
        [Required]
        public string? ContainerDbName { get; set; } = null;

        [JsonPropertyName("environment_db_name")]
        [JsonProperty(PropertyName = "environment_db_name")]
        [Required]
        public string? EnvironmentDbName { get; set; }

        [JsonPropertyName("environment_db_user")]
        [JsonProperty(PropertyName = "environment_db_user")]
        [Required]
        public string? EnvironmentDbUser { get; set; }

        [JsonPropertyName("environment_db_pwd")]
        [JsonProperty(PropertyName = "environment_db_pwd")]
        [Required]
        public string? EnvironmentDbPwd { get; set; }

        //[JsonPropertyName("container_port")]
        //[JsonProperty(PropertyName = "container_port")]
        //[StringLength(4, ErrorMessage = "Informe a porta do banco até 4 digitos.")]
        //[Required]
        //public string? ContainerPort { get; set; }

        [JsonPropertyName("container_volume")]
        [JsonProperty(PropertyName = "container_volume")]
        [Required]
        public string? ContainerVolume { get; set; }

        [JsonPropertyName("container_network")]
        [JsonProperty(PropertyName = "container_network")]
        [Required]
        public string? ContainerNetwork { get; set; }
    }
}
