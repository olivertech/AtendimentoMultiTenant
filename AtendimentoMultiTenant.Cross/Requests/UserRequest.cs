namespace AtendimentoMultiTenant.Cross.Requests
{
    public class UserRequest : RequestBase
    {
        [JsonPropertyName("user_name")]
        [JsonProperty(PropertyName = "user_name")]
        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value is not null)
                    _name = value.ToString().ToUpper();
            }
        }

        private string? _name;

        [JsonPropertyName("email")]
        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; } = null;

        [JsonPropertyName("password")]
        [JsonProperty(PropertyName = "password")]
        public string? Password { get; set; } = null;

        [JsonPropertyName("is_active")]
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; } = true;
    }
}
