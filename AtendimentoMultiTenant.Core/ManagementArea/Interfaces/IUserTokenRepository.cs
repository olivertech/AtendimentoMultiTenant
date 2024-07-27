namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface IUserTokenRepository : IRepositoryConfigurationBase<UserToken>
    {
        Task<UserToken?> GetToken(User user);
    }
}
