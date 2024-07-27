using AtendimentoMultiTenant.Shared.ManagementArea.Requests;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).Length(10, 150).NotNull().NotEqual("").EmailAddress().WithSeverity(Severity.Error);
            RuleFor(x => x.Password).Length(3, 50).NotNull().NotEqual("");
        }
    }
}
