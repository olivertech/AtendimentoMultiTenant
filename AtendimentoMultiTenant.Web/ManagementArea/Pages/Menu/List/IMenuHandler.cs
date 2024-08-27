namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu.List
{
	public interface IMenuHandler : IHandler<MenuRequest, MenuPagedRequest, MenuResponse>
	{
		Task<ResponseFactory<MenuResponse>> Delete(Guid id, string type);
	}
}
