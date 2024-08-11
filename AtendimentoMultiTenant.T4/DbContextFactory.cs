using AtendimentoMultiTenant.Infra.ManagementArea.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AtendimentoMultiTenant.T4
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ManagementAreaDbContext>
    {
        public ManagementAreaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ManagementAreaDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("ConfigConnection"));

            return new ManagementAreaDbContext(optionsBuilder.Options);
        }
    }
}
