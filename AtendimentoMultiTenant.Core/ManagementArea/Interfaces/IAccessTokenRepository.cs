namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface IAccessTokenRepository : IRepositoryConfigurationBase<AccessToken>
    {
        Task<AccessToken?> GetToken(User user);
    }
}
