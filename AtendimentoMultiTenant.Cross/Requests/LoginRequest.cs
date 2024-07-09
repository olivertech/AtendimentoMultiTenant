namespace AtendimentoMultiTenant.Cross.Requests
{
    public class LoginRequest
    {
        [JsonPropertyName("email")]
        [JsonProperty(PropertyName = "email")]
        [StringLength(150, ErrorMessage = "Informe email do usuário com até 150 caracteres.")]
        [Required]
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

        private string? _email;

        [JsonPropertyName("password")]
        [JsonProperty(PropertyName = "password")]
        [StringLength(50, ErrorMessage = "Informe senha do usuário com até 50 caracteres.")]
        [Required]
        public string? Password { get; set; } = null;
    }
}
