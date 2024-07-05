using System.ComponentModel.DataAnnotations;

namespace AtendimentoMultiTenant.Cross.Requests
{
    public class ContainerRequest : RequestBase
    {
        [JsonPropertyName("container_name")]
        [JsonProperty(PropertyName = "container_name")]
        [StringLength(250, ErrorMessage = "Informe nome do container com até 250 caracteres.")]
        [Required]
        public string? ContainerName { get; set; } = null;

        [JsonPropertyName("container_image")]
        [JsonProperty(PropertyName = "container_image")]
        [StringLength(250, ErrorMessage = "Informe imagem do container com até 250 caracteres.")]
        [Required]
        public string? ContainerImage { get; set; } = null;

        [JsonPropertyName("environment_db_name")]
        [JsonProperty(PropertyName = "environment_db_name")]
        [StringLength(250, ErrorMessage = "Informe nome do banco de dados com até 250 caracteres.")]
        [Required]
        public string? EnvironmentDbName { get; set; }

        [JsonPropertyName("environment_db_user")]
        [JsonProperty(PropertyName = "environment_db_user")]
        [StringLength(50, ErrorMessage = "Informe nome do usuário do banco com até 50 caracteres.")]
        [Required]
        public string? EnvironmentDbUser { get; set; }

        [JsonPropertyName("environment_db_pwd")]
        [JsonProperty(PropertyName = "environment_db_pwd")]
        [StringLength(50, ErrorMessage = "Informe senha do usuário do banco com até 50 caracteres.")]
        [Required]
        public string? EnvironmentDbPwd { get; set; }

        [JsonPropertyName("container_port")]
        [JsonProperty(PropertyName = "container_port")]
        [StringLength(4, ErrorMessage = "Informe a porta do banco até 4 digitos.")]
        [Required]
        public string? ContainerPort { get; set; }

        [JsonPropertyName("container_volume")]
        [JsonProperty(PropertyName = "container_volume")]
        [StringLength(50, ErrorMessage = "Informe nome do volume do container com até 50 caracteres.")]
        [Required]
        public string? ContainerVolume { get; set; }

        [JsonPropertyName("container_network")]
        [JsonProperty(PropertyName = "container_network")]
        [StringLength(50, ErrorMessage = "Informe nome da rede do container com até 50 caracteres.")]
        [Required]
        public string? ContainerNetwork { get; set; }

        [JsonPropertyName("container_created_at")]
        [JsonProperty(PropertyName = "container_created_at")]
        public DateOnly? ContainerCreatedAt { get; set; }

        [JsonPropertyName("is_up")]
        [JsonProperty(PropertyName = "is_up")]
        [Required]
        public bool IsUp { get; set; } = false;
    }
}
