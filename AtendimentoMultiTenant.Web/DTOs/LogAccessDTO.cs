using Newtonsoft.Json;

namespace AtendimentoMultiTenant.Web.DTOs
{
    public class LogAccessDTO
    {
        [JsonProperty(PropertyName = "user_id")]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateOnly? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "timed_at")]
        public TimeOnly? TimedAt { get; set; }
    }
}
