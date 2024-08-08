namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface ITenantRepository : IRepositoryConfigurationBase<Tenant>
    {
        Task<Tenant?> GetTenantBySecret(string secret);
    }
}
