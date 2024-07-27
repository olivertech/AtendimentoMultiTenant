namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base
{
    public abstract class RequestBase
    {
        [JsonPropertyName("id")]
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }
    }
}
