namespace AtendimentoMultiTenant.Cross.Responses
{
    public class ContainerResponse
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "container_name")]
        public string? ContainerName { get; set; } = null;

        [JsonProperty(PropertyName = "container_image")]
        public string? ContainerImage { get; set; } = null;

        [JsonProperty(PropertyName = "environment_db_name")]
        public string? EnvironmentDbName { get; set; }

        [JsonProperty(PropertyName = "environment_db_user")]
        public string? EnvironmentDbUser { get; set; }

        [JsonProperty(PropertyName = "environment_db_pwd")]
        public string? EnvironmentDbPwd { get; set; }

        [JsonProperty(PropertyName = "container_port")]
        public string? ContainerPort { get; set; }

        [JsonProperty(PropertyName = "container_volume")]
        public string? ContainerVolume { get; set; }

        [JsonProperty(PropertyName = "container_network")]
        public string? ContainerNetwork { get; set; }

        [JsonPropertyName("container_created_at")]
        [JsonProperty(PropertyName = "container_created_at")]
        public DateOnly? ContainerCreatedAt { get; set; }

        [JsonProperty(PropertyName = "is_up")]
        public bool IsUp { get; set; } = false;
    }
}
