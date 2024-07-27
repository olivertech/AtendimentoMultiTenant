namespace AtendimentoMultiTenant.Api.ManagementArea.Jobs
{
    /// <summary>
    /// Classe que tem as configurações do job de criação dos bancos de dados
    /// PostGreSql para os clientes, a ser criado em container docker, com
    /// os dodos personalizados no docker-compose.yml criado dinamicamente
    /// para cada novo cliente
    /// </summary>
    public class PostgreSqlContainerCreationJobSetup : IConfigureOptions<QuartzOptions>
    {
        public void Configure(QuartzOptions options)
        {
            var containerCreationJobKey = JobKey.Create(nameof(PostgreSqlContainerCreationJob));

            options
                .AddJob<PostgreSqlContainerCreationJob>(jobBuilder => jobBuilder.WithIdentity(containerCreationJobKey))
                .AddTrigger(trigger =>
                    trigger.ForJob(containerCreationJobKey)
                           .WithSimpleSchedule(schedule =>
                                schedule.WithIntervalInSeconds(10).RepeatForever()));
        }
    }
}
