namespace AtendimentoMultiTenant.Core.Entities.ConfigurationEntities
{
    /// <summary>
    /// Classe que representa os "inquilinos" do SaaS, ou seja,
    /// as empresas clientes que estão contratando o serviço
    /// </summary>
    public class Tenant : BaseConfigurationEntity
    {
        public string? Name { get; set; } = null;
        public string? Secret { get; set; } = null;
        public string? ConnectionString { get; set; } = null;
        public string? InitialUrl { get; set; } = null;
        public bool IsActive { get; set; }
    }
}
