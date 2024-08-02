namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class AccessTokenRepository : RepositoryConfigurationBase<AccessToken>, IAccessTokenRepository
    {
        public AccessTokenRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }

        public async Task<AccessToken?> GetToken(User user)
        {
            if (user == null)
                return null;

            return await _context!.TokenAccesses
                .Where(t => t.Id == user.TokenAccessId)
                .FirstOrDefaultAsync();
        }
    }
}
