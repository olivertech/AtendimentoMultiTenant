namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
    public class LogoutRequest : IRequest
    {
        [JsonPropertyName("user_id")]
        [JsonProperty(PropertyName = "user_id")]
        public Guid? UserId { get; set; }
    }
}
