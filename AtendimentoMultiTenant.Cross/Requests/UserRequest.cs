namespace AtendimentoMultiTenant.Cross.Requests
{
    public class UserRequest
    {
        [JsonPropertyName("user_name")]
        [JsonProperty(PropertyName = "user_name")]
        [StringLength(250, ErrorMessage = "Informe nome do usuário com até 250 caracteres.")]
        [Required]
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
        [StringLength(250, ErrorMessage = "Informe email do usuário com até 250 caracteres.")]
        [Required]
        public string? Email { get; set; } = null;

        [JsonPropertyName("password")]
        [JsonProperty(PropertyName = "password")]
        [StringLength(50, ErrorMessage = "Informe senha do usuário com até 50 caracteres.")]
        [Required]
        public string? Password { get; set; } = null;

        [JsonPropertyName("is_active")]
        [JsonProperty(PropertyName = "is_active")]
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
