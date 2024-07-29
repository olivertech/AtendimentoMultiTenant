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
        [Description("/ticketlist")]
        TicketList,
        [Description("/userlist")]
        UserList,
        [Description("/containerlist")]
        ContainerList,
    }
}
