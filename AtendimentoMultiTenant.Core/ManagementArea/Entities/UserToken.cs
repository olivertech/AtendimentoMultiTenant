using AtendimentoMultiTenant.Core.ManagementArea.Entities.Base;

namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    /// <summary>
    /// Classe que guarda os tokens de autorização dos usuários que acessam o sistema
    /// com a definição de um período de validade
    /// </summary>
    public sealed class UserToken : ConfigurationEntityBase
    {
        public string? Token { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
