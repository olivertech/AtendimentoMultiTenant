namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    /// <summary>
    /// Classe que representa os "inquilinos" do SaaS, ou seja,
    /// as empresas clientes que estão contratando o serviço
    /// </summary>
    public sealed class Tenant : ConfigurationEntityBase
    {
        public string? Name { get; set; } = null!;
        public string? Secret { get; set; } = null!;
        public string? ConnectionString { get; set; } = null!;
        public string? InitialUrl { get; set; } = null!;
        public DateOnly? CreatedAt { get; set; }
        public TimeOnly? TimedAt { get; set; }
        public DateOnly? DeativatedAt { get; set; }
        public TimeOnly? DeactivatedTimedAt { get; set; }
    }
}
