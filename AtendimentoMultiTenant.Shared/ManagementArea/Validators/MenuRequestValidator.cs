namespace AtendimentoMultiTenant.Shared.ManagementArea.Validators
{
    public class MenuRequestValidator : AbstractValidator<MenuRequest>
    {
        public MenuRequestValidator()
        {
            RuleFor(x => x.Name).Length(3, 250).NotEmpty().NotNull().NotEqual("").WithMessage("Informe o nome do menu entre 3 e 250 caracteres.");
            RuleFor(x =>x.Icone).Length(3, 50).NotEmpty().NotNull().NotEqual("").WithMessage("Informe o icone do menu entre 3 e 50 caracteres.");
            RuleFor(x => x.Route).Length(3, 250).NotEmpty().NotNull().NotEqual("").WithMessage("Informe a rota do menu entre 3 e 250 caracteres.");
            RuleFor(x => x.Description).NotEmpty().NotNull().NotEqual("").WithMessage("Informe a descrição do menu com até 1500 caracteres.");
        }
    }
}
