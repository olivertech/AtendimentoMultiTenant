namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface ISecretRepository : IRepositoryConfigurationBase<Secret>
    {
        Task<Secret?> GetSecretByTenant(Guid tenantId);
    }
}

