namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
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
    public class ContainerDb : ConfigurationEntityBase
    {
        public string? ContainerDbName { get; set; } = null;
        public string? ContainerDbImage { get; set; } = null;
        public string? EnvironmentDbName { get; set; }
        public string? EnvironmentDbUser { get; set; }
        public string? EnvironmentDbPwd { get; set; }
        public string? ContainerDbPort { get; set; }
        public string? ContainerDbVolume { get; set; }
        public string? ContainerDbNetwork { get; set; }
        public bool IsUp { get; set; } = false;
        public DateOnly? CreatedAt { get; set; }
        public TimeOnly? TimedAt { get; set; }
        public bool IsActive { get; set; }

        public Guid TenantId { get; set; }
        public Guid PortId { get; set; }

        //Navigation Property
        public Tenant? Tenant { get; set; }
        public Port? Port { get; set; }
    }
}
