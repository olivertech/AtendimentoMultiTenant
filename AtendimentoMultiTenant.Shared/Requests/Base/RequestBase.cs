namespace AtendimentoMultiTenant.Shared.Requests.Base
{
    public abstract class RequestBase
    {
        [JsonPropertyName("id")]
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }
    }
}
