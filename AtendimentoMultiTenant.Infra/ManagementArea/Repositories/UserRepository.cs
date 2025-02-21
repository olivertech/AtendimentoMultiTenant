﻿namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class UserRepository : RepositoryConfigurationBase<User>, IUserRepository
    {
        public UserRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmail(string email)
        {
            if (email == null)
                return null;

            return await _context!.Users
                .Include(ut => ut.Role)
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> ValidateLogin(string email, string password)
        {
            if (email == null || password == null)
                return null;

            return await _context!.Users!
                .Include(ur => ur.Role!)
                .Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();
        }
    }
}
