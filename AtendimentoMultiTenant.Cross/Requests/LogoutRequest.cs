namespace AtendimentoMultiTenant.Cross.Requests
{
    public class LogoutRequest
    {
        [JsonPropertyName("user_id")]
        [JsonProperty(PropertyName = "user_id")]
        public Guid? UserId { get; set; }
    }
}
