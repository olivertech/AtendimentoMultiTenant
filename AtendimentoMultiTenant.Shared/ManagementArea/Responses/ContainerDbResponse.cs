namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public class ContainerDbResponse : IResponse
    {
        public Guid Id { get; set; }

        public string? ContainerDbName { get; set; } = null;

        public string? ContainerDbImage { get; set; } = null;

        public string? EnvironmentDbName { get; set; }

        public string? EnvironmentDbUser { get; set; }

        public string? EnvironmentDbPwd { get; set; }

        public string? ContainerDbPort { get; set; }

        public string? ContainerDbVolume { get; set; }

        public string? ContainerDbNetwork { get; set; }

        public DateOnly? ContainerDbCreatedAt { get; set; }

        public bool IsUp { get; set; } = false;

        public bool IsActive { get; set; }
    }
}
