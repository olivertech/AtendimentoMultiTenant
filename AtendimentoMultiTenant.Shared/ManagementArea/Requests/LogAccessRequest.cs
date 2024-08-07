namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
    public class LogAccessRequest : IRequest
    {
        [JsonPropertyName("user_id")]
        [JsonProperty(PropertyName = "user_id")]
        public Guid UserId { get; set; }

        [JsonPropertyName("created_at")]
        [JsonProperty(PropertyName = "created_at")]
        public DateOnly? CreatedAt { get; set; }

        [JsonPropertyName("timed_at")]
        [JsonProperty(PropertyName = "timed_at")]
        public TimeOnly? TimedAt { get; set; }
    }
}
