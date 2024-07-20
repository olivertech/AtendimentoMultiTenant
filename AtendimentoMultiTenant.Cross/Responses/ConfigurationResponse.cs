namespace AtendimentoMultiTenant.Cross.Responses
{
    public abstract class ConfigurationResponse
    {
        [JsonProperty(PropertyName = "client_name")]
        public string? ClientName { get; set; } = null;

        [JsonProperty(PropertyName = "container_name")]
        public string? ContainerName { get; set; } = null;

        [JsonProperty(PropertyName = "environment_db_name")]
        public string? EnvironmentDbName { get; set; }

        [JsonProperty(PropertyName = "environment_db_user")]
        public string? EnvironmentDbUser { get; set; }

        [JsonProperty(PropertyName = "environment_db_pwd")]
        public string? EnvironmentDbPwd { get; set; }

        [JsonProperty(PropertyName = "container_volume")]
        public string? ContainerVolume { get; set; }

        [JsonProperty(PropertyName = "container_network")]
        public string? ContainerNetwork { get; set; }

        [JsonProperty(PropertyName = "tenant")]
        public Tenant? Tenant { get; set; }

        [JsonProperty(PropertyName = "port")]
        public Port? Port { get; set; }

    }
}
