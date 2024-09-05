namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    /// <summary>
    /// Response que retorna apenas algumas propriedades do user
    /// confirmando o seu login junto com o token de acesso
    /// </summary>
    public class LoginResponse : IResponse
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = null!;

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; } = null!;

        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; } = true;

        [JsonProperty(PropertyName = "role")]
        public Role Role { get; set; } = null!;

        [JsonPropertyName("access_token")]
        [JsonProperty(PropertyName = "access_token")]
        public AccessToken AccessToken { get; set; } = null!;
    }
}
