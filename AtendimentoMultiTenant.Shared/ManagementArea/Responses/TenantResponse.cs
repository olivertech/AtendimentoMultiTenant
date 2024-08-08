namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public class TenantResponse : IResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; } = null!;

        [JsonProperty(PropertyName = "secret")]
        public string? Secret { get; set; } = null!;

        [JsonProperty(PropertyName = "deativated_at")]
        public DateOnly? DeativatedAt { get; set; }

        [JsonProperty(PropertyName = "deactivated_timed_at")]
        public TimeOnly? DeactivatedTimedAt { get; set; }
    }
}
