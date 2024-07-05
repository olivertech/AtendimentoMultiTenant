namespace AtendimentoMultiTenant.Core.Entities.ConfigurationEntities
{
    /// <summary>
    /// Classe que representa os usuários que podem acessar os sistemas "inquilinos",
    /// ou seja, todos que tem permissão de logar nos seus respectivos sistemas clientes
    /// </summary>
    public class User : ConfigurationEntityBase
    {
        public string? Name { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Password { get; set; } = null;
        public bool IsActive { get; set; }

        public Guid TenantId { get; set; }

        //Navigation Property
        public Tenant? Tenant { get; set; }
    }
}
