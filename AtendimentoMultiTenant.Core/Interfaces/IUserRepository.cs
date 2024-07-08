namespace AtendimentoMultiTenant.Core.Interfaces
{
    public interface IUserRepository : IRepositoryConfigurationBase<User>
    {
        Task<User?> GetByEmail(string email);
    }
}
