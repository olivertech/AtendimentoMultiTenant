namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class UserRepository : RepositoryConfigurationBase<User>, IUserRepository
    {
        public UserRepository([NotNull] AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmail(string email)
        {
            if (email == null)
                return null;
            
            return await _context!.Users
                .Include(ut => ut.UserType)
                .Where(ut => ut.Email == email)
                .FirstOrDefaultAsync();
        }
    }
}
