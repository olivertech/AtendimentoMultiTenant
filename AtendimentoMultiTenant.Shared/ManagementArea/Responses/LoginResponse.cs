namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    /// <summary>
    /// Response que retorna apenas algumas propriedades do user
    /// confirmando o seu login junto com o token de acesso
    /// </summary>
    public class LoginResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public Role Role { get; set; } = null!;

        public AccessToken AccessToken { get; set; } = null!;
    }
}
