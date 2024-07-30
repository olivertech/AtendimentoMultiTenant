namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    /// <summary>
    /// Classe que guarda os tokens de autorização dos usuários que acessam o sistema
    /// com a definição de um período de validade
    /// </summary>
    public sealed class TokenAccess : ConfigurationEntityBase
    {
        public string? Token { get; set; }
        public DateOnly? CreatedAt { get; set; }
        public TimeOnly? TimedAt { get; set; }
        public DateOnly? ExpiringAt { get; set; }
    }
}
