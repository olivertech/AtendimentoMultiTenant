namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public class LogAccessResponse : IResponse
    {
        [JsonProperty(PropertyName = "user_id")]
        public Guid UserId { get; set; } = new();

        [JsonProperty(PropertyName = "created_at")]
        public DateOnly? CreatedAt { get; set; } = null!;

        [JsonProperty(PropertyName = "timed_at")]
        public TimeOnly? TimedAt { get; set; } = null!;

        [JsonProperty(PropertyName = "user")]
        public User? User { get; set; }
    }
}
