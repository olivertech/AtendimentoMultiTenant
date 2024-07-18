namespace AtendimentoMultiTenant.Cross.Validators
{
    public class ConfigurationRequestValidator : AbstractValidator<ConfigurationRequest>
    {
        public ConfigurationRequestValidator()
        {
            RuleFor(x => x.ClientName).Length(10, 50).NotNull().NotEqual("").WithMessage("Informe nome do cliente com até 50 caracteres, sem espaços e sem caracteres especiais.");
            RuleFor(x => x.ContainerDbName).Length(10, 250).NotNull().NotEqual("").Must(x => x.EndsWith("_postgresql")).WithMessage("Informe nome do container com até 250 caracteres.");
            RuleFor(x => x.EnvironmentDbName).Length(10, 250).NotNull().NotEqual("").Must(x => x.EndsWith("_db")).WithMessage("Informe nome do container com até 250 caracteres.");
            RuleFor(x => x.EnvironmentDbUser).Length(5, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_user_db")).WithMessage("<NOMECLIENTE>_user_db");
            RuleFor(x => x.EnvironmentDbPwd).Length(5, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_db")).WithMessage("!<NOMECLIENTE>@<ANO4DIGITOS><MES2DIGITOS><DIA2DIGITOS>#");
            RuleFor(x => x.ContainerDbVolume).Length(5, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_volume")).WithMessage("<NOMECLIENTE>_volume");
            RuleFor(x => x.ContainerDbNetwork).Length(5, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_network")).WithMessage("<NOMECLIENTE>_network");
        }
    }
}
