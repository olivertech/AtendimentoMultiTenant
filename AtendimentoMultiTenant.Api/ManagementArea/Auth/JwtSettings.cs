namespace AtendimentoMultiTenant.Api.ManagementArea.Auth
{
    /// <summary>
    /// Secret Key usada para gerar os tokens de autorização e autenticação
    /// 
    /// Atenção: A SecretKey precisa ter 32 caracteres para funcionar
    /// </summary>
    public static class JwtSettings
    {
        /// <summary>
        /// JWT Authentication Secret Key
        /// </summary>
        public static string SecretKey = SharedConfigurations.SecretKey;

        /// <summary>
        /// Authentication Development Server Domain URL Base Address
        /// </summary>
        public static string JwtIssuer = SharedConfigurations.JwtIssuer;

        /// <summary>
        /// Client Application Development Domain URL Base Address
        /// </summary>
        public static string JwtAudience = SharedConfigurations.JwtAudiencie;
    }
}
