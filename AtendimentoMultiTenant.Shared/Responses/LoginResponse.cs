namespace AtendimentoMultiTenant.Shared.Responses
{
    /// <summary>
    /// Response que retorna apenas algumas propriedades do user
    /// confirmando o seu login junto com o token de acesso
    /// </summary>
    public class LoginResponse : IResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = null!;

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; } = null!;

        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; } = true;

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; } = null!;

        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; } = null!;
    }
}
