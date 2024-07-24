namespace AtendimentoMultiTenant.Core.Classes
{
    /// <summary>
    /// Classe que mantém todas as principais configurações do sistema
    /// </summary>
    public static class CoreConfigurations
    {
        public const int PAGESIZE = 25;
        public const string CRYPTOKEY = "Myx2szzzdBJQ65UD"; //Encrypt and Decrypt key
        public const int MINUTES = 1440; //1 Day

        public static string FrontendUrl { get; } = "https://localhost:7282";
        public static string BackendUrl { get; } = "https://localhost:7168";
    }
}
