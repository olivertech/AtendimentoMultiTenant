namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface ITokenAccessRepository : IRepositoryConfigurationBase<TokenAccess>
    {
        Task<TokenAccess?> GetToken(User user);
    }
}
