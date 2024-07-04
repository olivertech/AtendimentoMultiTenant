namespace AtendimentoMultiTenant.Core.Entities.ConfigurationEntities
{
    /// <summary>
    /// Classe que vai conter as propriedades que formarão o arquivo docker-compose.yml
    /// montado em tempo de execução, para criar um novo container com o banco de dados
    /// do tenant que assinar um plano no SaaS
    /// 
    ///db_config:
    ///    container_name: <NOME-DO-CLIENTE>
    ///    image: postgres:16.2
    ///    environment:
    ///        - POSTGRES_DB=<NOME-DO-BANCO>
    ///        - POSTGRES_USER=<NOME-DO-USUARIO-DO-BANCO>
    ///        - POSTGRES_PASSWORD=<SENHA-DO-USUARIO-DO-BANCO>
    ///        - POSTGRES_HOST_AUTH_METHOD=trust
    ///    ports:
    ///        - <PORTA>:5432
    ///    volumes:
    ///        - <VOLUME>:/var/lib/postgresql/data
    ///    restart: always
    ///    networks:
    ///        - <NETWORK>
    /// </summary>
    public class Container : BaseConfigurationEntity
    {
        public string? ContainerName { get; set; } = null;
        public string? ContainerImage { get; set; } = null;
        public string? EnvironmentDbName { get; set; }
        public string? EnvironmentDbUser { get; set; }
        public string? EnvironmentDbPwd { get; set; }
        public string? ContainerPort { get; set; }
        public string? ContainerVolume { get; set; }
        public string? ContainerNetwork { get; set; }
        public bool IsUp { get; set; } = false;
        public DateOnly? ContainerCreatedAt { get; set; }

        public Guid TenantId { get; set; }

        //Navigation Property
        public Tenant? Tenant { get; set; }
    }
}
