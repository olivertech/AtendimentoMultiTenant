﻿namespace AtendimentoMultiTenant.Cross.Validators
{
    public class ContainerDbRequestValidator : AbstractValidator<ContainerDbRequest>
    {
        public ContainerDbRequestValidator() 
        {
            RuleFor(x => x.ContainerDbName).Length(10, 250).NotNull().NotEqual("").Must(x => x.EndsWith("_postgresql")).WithMessage("Se certifique de passar o nome do cliente no prefixo.");
            RuleFor(x => x.EnvironmentDbName).Length(10, 250).NotNull().NotEqual("").Must(x => x.EndsWith("_db")).WithMessage("Se certifique de passar o nome do cliente no prefixo.");
            RuleFor(x => x.EnvironmentDbUser).Length(10, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_user_db")).WithMessage("Se certifique de passar o nome do cliente no prefixo.");
            RuleFor(x => x.EnvironmentDbPwd).Length(10, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_user_db")).WithMessage("!<NOMECLIENTE>@<ANO4DIGITOS><MES2DIGITOS><DIA2DIGITOS>#");
            RuleFor(x => x.ContainerVolume).Length(10, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_volume")).WithMessage("Informe nome do volume do container com até 50 caracteres.");
            RuleFor(x => x.ContainerNetwork).Length(10, 50).NotNull().NotEqual("").Must(x => x.EndsWith("_network")).WithMessage("Informe nome da rede do container com até 50 caracteres.");
        }
    }
}
