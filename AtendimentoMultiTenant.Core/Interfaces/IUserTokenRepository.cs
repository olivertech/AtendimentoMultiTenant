namespace AtendimentoMultiTenant.Core.Interfaces
{
    public interface IUserTokenRepository : IRepositoryConfigurationBase<UserToken>
    {
        Task<UserToken?> GetToken(User user);
    }
}
