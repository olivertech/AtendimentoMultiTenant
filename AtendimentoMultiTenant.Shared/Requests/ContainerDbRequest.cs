namespace AtendimentoMultiTenant.Shared.Requests
{
    public class ContainerDbRequest : RequestBase, IRequest
    {
        [JsonPropertyName("container_name")]
        [JsonProperty(PropertyName = "container_name")]
        public string? ContainerDbName { get; set; } = null;

        [JsonPropertyName("environment_db_name")]
        [JsonProperty(PropertyName = "environment_db_name")]
        public string? EnvironmentDbName { get; set; }

        [JsonPropertyName("environment_db_user")]
        [JsonProperty(PropertyName = "environment_db_user")]
        public string? EnvironmentDbUser { get; set; }

        [JsonPropertyName("environment_db_pwd")]
        [JsonProperty(PropertyName = "environment_db_pwd")]
        public string? EnvironmentDbPwd { get; set; }

        [JsonPropertyName("container_volume")]
        [JsonProperty(PropertyName = "container_volume")]
        public string? ContainerVolume { get; set; }

        [JsonPropertyName("container_network")]
        [JsonProperty(PropertyName = "container_network")]
        public string? ContainerNetwork { get; set; }
    }
}
