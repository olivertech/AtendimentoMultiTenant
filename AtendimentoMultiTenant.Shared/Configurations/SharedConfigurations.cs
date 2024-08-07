namespace AtendimentoMultiTenant.Shared.Configurations
{
    public static class SharedConfigurations
    {
        /// <summary>
        /// Jwt Parameters
        /// </summary>
        public static readonly string JwtAudiencie = "https://localhost:7282";
        public static readonly string JwtIssuer = "https://localhost:7168";
        public static readonly string SecretKey = "8ykjeycuknBEuP8PZUYUpQftxtEa7fHx";

        /// <summary>
        /// HttpClientFactory Parameter
        /// </summary>
        public static readonly string HttpClientName = "Api";

        /// <summary>
        /// Pagination Parameter
        /// Obs: Esse parâmetro deve ser mantido como const
        /// </summary>
        public const int PageSize = 25;

        /// <summary>
        /// Encryption Parameters
        /// </summary>
        public static readonly string CryotKey = "Myx2szzzdBJQ65UD"; //Encrypt and Decrypt key
        public static readonly int Minutes = 1440; //1 Day

        /// <summary>
        /// Cors Parameters
        /// </summary>
        public static readonly string FrontEndUrl = "https://localhost:7282";
        public static readonly string BackEndUrl = "https://localhost:7168";
    }
}
