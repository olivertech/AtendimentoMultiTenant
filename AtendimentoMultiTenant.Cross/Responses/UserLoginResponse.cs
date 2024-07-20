namespace AtendimentoMultiTenant.Cross.Responses
{
    /// <summary>
    /// Response que retorna apenas algumas propriedades do user
    /// confirmando o seu login junto com o token de acesso
    /// </summary>
    public abstract class UserLoginResponse
    {
        public string? Name { get; set; } = null;
        public string? Email { get; set; } = null;
        public bool IsActive { get; set; }
        public Guid TenantId { get; set; }
        public Guid? UserTypeId { get; set; }
        public Guid? UserTokenId { get; set; }
    }
}
