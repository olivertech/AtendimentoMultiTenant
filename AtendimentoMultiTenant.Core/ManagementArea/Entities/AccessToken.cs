namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    /// <summary>
    /// Classe que guarda os tokens de autorização dos usuários que acessam o sistema
    /// com a definição de um período de validade
    /// </summary>
    public class AccessToken : ConfigurationEntityBase
    {
        public string? Token { get; set; } = null!;
        public DateOnly? CreatedAt { get; set; }
        public TimeOnly? TimedAt { get; set; }
        public DateOnly? ExpiringAt { get; set; }
    }
}
