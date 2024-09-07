namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public class MenuResponse : IResponse
    {
        public Guid Id { get; set; }

        public string? Name { get; set; } = null;

        public string? Icone { get; set; } = null;

        public string? Route { get; set; } = null;

        public string? Description { get; set; } = null;

        public bool IsActive { get; set; }
    }
}
