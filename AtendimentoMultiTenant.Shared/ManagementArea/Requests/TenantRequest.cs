﻿namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
    public class TenantRequest : RequestBase, IRequest
    {
        [JsonPropertyName("name")]
        [JsonProperty(PropertyName = "name")]
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

        [JsonPropertyName("description")]
        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; } = null;

        [JsonPropertyName("connection_string")]
        [JsonProperty(PropertyName = "connection_string")]
        public string? ConnectionString { get; set; } = null;

        [JsonPropertyName("initial_url")]
        [JsonProperty(PropertyName = "initial_url")]
        public string? InitialUrl { get; set; } = null;

        [JsonPropertyName("is_active")]
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; } = true;
    }
}
