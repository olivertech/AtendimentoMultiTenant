namespace AtendimentoMultiTenant.Web.ManagementArea.Components.LeftMenu
{
    public interface ILeftMenuHandler
    {
        Task<List<LeftMenuItem>?> GetLeftMenuItens();
    }
}
