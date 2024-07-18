namespace AtendimentoMultiTenant.Cross.Requests
{
    public class LoginRequest
    {
        [JsonPropertyName("email")]
        [JsonProperty(PropertyName = "email")]
        public string? Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value is not null)
                    _email = value.ToString().ToLower();
            }
        }

        private string? _email = string.Empty;

        [JsonPropertyName("password")]
        [JsonProperty(PropertyName = "password")]
        public string? Password { get; set; } = string.Empty;
    }
}
