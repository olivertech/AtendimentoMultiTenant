﻿namespace AtendimentoMultiTenant.Shared.Responses
{
    /// <summary>
    /// Response que retorna apenas algumas propriedades do user
    /// confirmando o seu login junto com o token de acesso
    /// </summary>
    public class UserLoginResponse : IResponse
    {
        public string? Name { get; set; } = null;
        public string? Email { get; set; } = null;
        public bool IsActive { get; set; }
        public string? Identifier { get; set; }
    }
}