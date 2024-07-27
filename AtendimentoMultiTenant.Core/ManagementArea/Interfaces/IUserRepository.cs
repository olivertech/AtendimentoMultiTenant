namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface IUserRepository : IRepositoryConfigurationBase<User>
    {
        Task<User?> GetByEmail(string email);
        Task<User?> ValidateLogin(string email, string password);
    }
}
