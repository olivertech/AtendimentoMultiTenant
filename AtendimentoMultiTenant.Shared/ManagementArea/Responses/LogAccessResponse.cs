namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public class LogAccessResponse : IResponse
    {
        public Guid UserId { get; set; } = new();

        public DateOnly? CreatedAt { get; set; } = null!;

        public TimeOnly? TimedAt { get; set; } = null!;

        public User? User { get; set; }
    }
}
