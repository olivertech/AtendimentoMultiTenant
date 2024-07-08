namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class UserTokenRepository : RepositoryConfigurationBase<UserToken>, IUserTokenRepository
    {
        public UserTokenRepository([NotNull] AppDbContext context) : base(context)
        {
        }

        public async Task<UserToken?> GetToken(User user)
        {
            if (user == null)
                return null;

            return await _context!.UserTokens
                .Where(t => t.Id == user.UserTokenId)
                .FirstOrDefaultAsync();
        }
    }
}
