using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public class ContainerDbResponse : IResponse
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "container_db_name")]
        public string? ContainerDbName { get; set; } = null;

        [JsonProperty(PropertyName = "container_db_image")]
        public string? ContainerDbImage { get; set; } = null;

        [JsonProperty(PropertyName = "environment_db_name")]
        public string? EnvironmentDbName { get; set; }

        [JsonProperty(PropertyName = "environment_db_user")]
        public string? EnvironmentDbUser { get; set; }

        [JsonProperty(PropertyName = "environment_db_pwd")]
        public string? EnvironmentDbPwd { get; set; }

        [JsonProperty(PropertyName = "container_db_port")]
        public string? ContainerDbPort { get; set; }

        [JsonProperty(PropertyName = "container_db_volume")]
        public string? ContainerDbVolume { get; set; }

        [JsonProperty(PropertyName = "container_db_network")]
        public string? ContainerDbNetwork { get; set; }

        [JsonProperty(PropertyName = "container_db_created_at")]
        public DateOnly? ContainerDbCreatedAt { get; set; }

        [JsonProperty(PropertyName = "is_up")]
        public bool IsUp { get; set; } = false;

        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }
    }
}
