namespace AtendimentoMultiTenant.Cross.Requests.Base
{
    public class RequestBase
    {
        [JsonPropertyName("id")]
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }
    }
}
