namespace AtendimentoMultiTenant.Shared.CommonArea.Enumerators
{
    public enum RoutesEnumerator
    {
        [Description("/error")]
        Error,
        [Description("/")]
        Index,
        [Description("/login")]
        Login,
        [Description("/configdashboard")]
        Dashboard,
        [Description("/containers")]
        Containers,
        [Description("/containerdetail")]
        ContainerDetail,
        [Description("/logs")]
        Logs,
        [Description("/menus")]
        Menus,
        [Description("/menudetail")]
        MenuDetail,
    }
}
