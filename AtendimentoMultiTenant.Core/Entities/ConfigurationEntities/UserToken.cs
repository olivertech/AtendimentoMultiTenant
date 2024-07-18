namespace AtendimentoMultiTenant.Core.Entities.ConfigurationEntities
{
    /// <summary>
    /// Classe que guarda os tokens de autorização dos usuários que acessam o sistema
    /// com a definição de um período de validade
    /// </summary>
    public sealed class UserToken : ConfigurationEntityBase
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
