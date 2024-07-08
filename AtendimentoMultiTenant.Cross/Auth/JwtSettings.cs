namespace AtendimentoMultiTenant.Cross.Auth
{
    /// <summary>
    /// Secret Key usada para gerar os tokens de autorização e autenticação
    /// 
    /// Atenção: A SecretKey precisa ter 32 caracteres para funcionar
    /// </summary>
    public static class JwtSettings
    {
        public static string SecretKey = "8ykjeycuknBEuP8PZUYUpQftxtEa7fHx";
    }
}
