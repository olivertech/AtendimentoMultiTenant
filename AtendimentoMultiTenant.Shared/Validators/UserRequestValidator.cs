namespace AtendimentoMultiTenant.Shared.Validators
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.Name).Length(5, 250).NotNull().NotEqual("");
            RuleFor(x => x.Email).Length(5, 250).NotNull().NotEqual("");
            RuleFor(x => x.Password).Length(5, 50).NotNull().NotEqual("");
            RuleFor(x => x.IsActive).NotNull();
        }
    }
}
