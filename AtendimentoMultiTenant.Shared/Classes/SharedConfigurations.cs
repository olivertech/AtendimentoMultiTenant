namespace AtendimentoMultiTenant.Shared.Classes
{
    public static class SharedConfigurations
    {
        public const string HttpClientName = "Api";
        public const int PAGESIZE = 25;
        public const string CRYPTOKEY = "Myx2szzzdBJQ65UD"; //Encrypt and Decrypt key
        public const int MINUTES = 1440; //1 Day

        public static readonly string FrontendUrl = "https://localhost:7282";
        public static readonly string BackendUrl = "https://localhost:7168";
    }
}
