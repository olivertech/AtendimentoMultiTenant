using AtendimentoMultiTenant.Core.ManagementArea.Entities;
using AtendimentoMultiTenant.Core.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Infra.ManagementArea.Context;
using AtendimentoMultiTenant.Infra.ManagementArea.Repositories.Base;
using System.Diagnostics.CodeAnalysis;

namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
	public class RoleRepository : RepositoryConfigurationBase<Role>, IRoleRepository
	{
		public RoleRepository([NotNull] ManagementAreaDbContext context) : base(context)
		{}
	}
}
