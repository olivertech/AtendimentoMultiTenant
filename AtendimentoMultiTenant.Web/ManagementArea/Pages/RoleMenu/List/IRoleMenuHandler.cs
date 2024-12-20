namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.RoleMenu.List
{
	public interface IRoleMenuHandler : IHandler<RoleMenuRequest, RoleMenuPagedRequest, RoleMenuResponse>
	{
		Task<ResponseFactory<IEnumerable<RoleMenuResponse>>> GetRoleMenuList(string id);
	}
}
