﻿namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
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

        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; } = null!;

        [JsonProperty(PropertyName = "role")]
        public Role Role { get; set; } = null!;

        [JsonProperty(PropertyName = "token_access")]
        public TokenAccess TokenAccess { get; set; } = null!;
    }
}
