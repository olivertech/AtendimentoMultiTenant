namespace AtendimentoMultiTenant.Shared.ManagementArea.Validators
{
    public class ContainerDbRequestValidator : AbstractValidator<ContainerDbRequest>
    {
        public ContainerDbRequestValidator()
        {
            //RuleFor(x => x.ClientName).Length(10, 50).NotNull().NotEqual("").WithMessage("Informe nome do cliente com até 50 caracteres, sem espaços e sem caracteres especiais.");
            RuleFor(x => x.ContainerDbName).Length(10, 250).NotNull().NotEqual("").Must(x => x.EndsWith("_postgresql")).WithMessage("Se certifique de passar o sufixo '_postgresql' no nome.");
            RuleFor(x => x.EnvironmentDbName).Length(10, 250).NotNull().NotEqual("").Must(x => x.EndsWith("_db")).WithMessage("Se certifique de passar o sufixo '_db' no nome.");
            RuleFor(x => x.EnvironmentDbUser).Length(10, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_user_db")).WithMessage("Se certifique de passar o sufixo '_user_db' no nome.");
            RuleFor(x => x.EnvironmentDbPwd).Length(3, 50).NotNull().NotEqual("").WithMessage("Informe a senha entre 3 e 50 caracteres.");
            RuleFor(x => x.ContainerDbVolume).Length(10, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_volume")).WithMessage("Se certifique de passar o sufixo '_volume' no nome.");
            RuleFor(x => x.ContainerDbNetwork).Length(10, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_network")).WithMessage("Se certifique de passar o sufixo '_network' no nome.");
        }
    }
}
