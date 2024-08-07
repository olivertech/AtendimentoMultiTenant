namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Components.LeftMenu
{
    public interface ILeftMenuHandler
    {
        Task<List<LeftMenuItem>?> GetLeftMenuItens();
    }
}
