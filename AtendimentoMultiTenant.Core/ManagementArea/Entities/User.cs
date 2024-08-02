namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    /// <summary>
    /// Classe que representa os usuários que podem acessar os sistemas "inquilinos",
    /// ou seja, todos que tem permissão de logar nos seus respectivos sistemas clientes
    /// </summary>
    public class User : ConfigurationEntityBase
    {
        public string? Name { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public DateOnly? CreatedAt { get; set; }
        public TimeOnly? TimedAt { get; set; }
        public DateOnly? DeativatedAt { get; set; }
        public TimeOnly? DeactivatedTimedAt { get; set; }

        public Guid TenantId { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? TokenAccessId { get; set; }

        //Navigation Property
        public Tenant? Tenant { get; set; }
        public Role? Role { get; set; }
        public AccessToken? TokenAccess { get; set; }

        // Many-to-many relation
        public List<UserFeature>? UserFeatures { get; set; }
    }
}
