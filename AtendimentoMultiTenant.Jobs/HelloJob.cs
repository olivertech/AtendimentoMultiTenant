using Ductus.FluentDocker.Extensions;
using Ductus.FluentDocker.Model.Common;
using Microsoft.Extensions.Configuration;
using Quartz;
using System.Configuration;

namespace AtendimentoMultiTenant.Jobs
{
    public class HelloJob : IJob
    {
        protected IConfiguration? _configuration;

        public HelloJob(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("Gerando o container...");

            string folder = _configuration!.GetSection("PastaDockerComposes").Value!;

            var file = folder + "\\docker-compose.yml";

            using (var svc = new Ductus.FluentDocker.Builders.Builder()
                        .UseContainer()
                        .UseCompose()
                        .FromFile(file)
                        .RemoveOrphans()
                        .Build().Start())
            {}

            await Console.Out.WriteLineAsync("Container gerado!!!");
        }
    }
}
