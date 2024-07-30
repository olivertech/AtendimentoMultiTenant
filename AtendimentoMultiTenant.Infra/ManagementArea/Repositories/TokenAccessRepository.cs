namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class TokenAccessRepository : RepositoryConfigurationBase<TokenAccess>, ITokenAccessRepository
    {
        public TokenAccessRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }

        public async Task<TokenAccess?> GetToken(User user)
        {
            if (user == null)
                return null;

            return await _context!.TokenAccesses
                .Where(t => t.Id == user.TokenAccessId)
                .FirstOrDefaultAsync();
        }
    }
}
