namespace AtendimentoMultiTenant.Shared.CommonArea.Enumerators
{
    public enum RoutesEnumerator
    {
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
        Logs
    }
}
