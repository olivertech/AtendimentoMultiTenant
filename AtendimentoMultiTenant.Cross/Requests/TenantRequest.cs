﻿using AtendimentoMultiTenant.Cross.Requests.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
namespace AtendimentoMultiTenant.Cross.Requests
{
    public class TenantRequest : RequestBase
    {
        [JsonPropertyName("name")]
        [JsonProperty(PropertyName = "name")]
        [StringLength(250, ErrorMessage = "Informe nome do usuário com até 50 caracteres.")]
        [Required]
        public string? Name { get; set; } = null;

        [JsonPropertyName("secret")]
        [JsonProperty(PropertyName = "secret")]
        public string? Secret { get; set; } = null;

        [JsonPropertyName("connection_string")]
        [JsonProperty(PropertyName = "connection_string")]
        [Required]
        public string? ConnectionString { get; set; } = null;

        [JsonPropertyName("id")]
        [JsonProperty(PropertyName = "id")]
        public string? InitialUrl { get; set; } = null;

        [JsonPropertyName("id")]
        [JsonProperty(PropertyName = "id")]
        public bool IsActive { get; set; } = true;
    }
}
