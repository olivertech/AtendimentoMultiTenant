using AtendimentoMultiTenant.Shared.ManagementArea.Requests;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Validators
{
    public class TenantRequestValidator : AbstractValidator<TenantRequest>
    {
        public TenantRequestValidator()
        {
            RuleFor(x => x.Name).Length(5, 250).NotNull().NotEqual("");
            RuleFor(x => x.ConnectionString).NotNull().NotEqual("");
        }
    }
}
