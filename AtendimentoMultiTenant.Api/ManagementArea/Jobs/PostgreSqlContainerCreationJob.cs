namespace AtendimentoMultiTenant.Api.ManagementArea.Jobs
{
    /// <summary>
    /// Classe que representa o Job que vai percorrer todos 
    /// os registros da tabela Container do banco AtendimentoConfigDB
    /// que contém todas as informações que são coletadas para 
    /// montar um a um, os arquivos docker-compose.yml, para posterior
    /// execução e levantamento de containers para cada banco de dados
    /// dos clientes novos que assinam a plataforma
    /// </summary>
    public class PostgreSqlContainerCreationJob : IJob
    {
        private readonly IConfiguration? _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PostgreSqlContainerCreationJob>? _logger;

        public PostgreSqlContainerCreationJob(IConfiguration configuration,
                                              IUnitOfWork unitOfWork,
                                              ILogger<PostgreSqlContainerCreationJob>? logger)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Formato do arquivo docker-compose.yml:
        /// 
        /// version: "3.8"
        /// services:
        ///  db_data:
        ///       container_name: postgresql_tenants
        ///       image: postgres: 16.2
        ///       environment:
        ///          - POSTGRES_DB = AtendimentoTenantDB
        ///          - POSTGRES_USER = postgrestenantuser
        ///          - POSTGRES_PASSWORD = atendimento@tenant
        ///          - POSTGRES_HOST_AUTH_METHOD = trust
        ///       ports:
        ///          -5433:5432
        ///       volumes:
        ///          -db_tenant_volume:/var/lib/postgresql/data
        ///       restart: always
        ///       networks:
        ///          -db_tenant_network
        /// volumes: 
        ///    db_tenant_volume:
        /// networks: 
        ///    db_tenant_network:
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                //Recupera do arquivo appsettings.json o caminho onde estão os arquivos associados a criação dos containers e também remoção dos containers
                string folder = _configuration!.GetSection("PastaDockerComposes").Value!;

                //Recupera todos os registros que da tabela Container, que ainda não
                //tenha sido processados e gerados os seus respectivos containers
                IEnumerable<ContainerDb>? containersToUp = await _unitOfWork.ContainerDbRepository.GetList(x => x.IsUp == false && x.IsActive == true);

                string folderCliente = string.Empty;

                //Caso existam registros de containers ainda a serem levantados
                if (containersToUp!.Any())
                {
                    foreach (var container in containersToUp!)
                    {
                        folderCliente = Path.Combine(folder, container!.ContainerDbName! + "_Up");

                        //Caso por algum motivo o folder ainda exista, remove
                        RemoveFolderAndFiles(folderCliente, folder);

                        //Recria o folder com o nome do cliente
                        Directory.CreateDirectory(folderCliente);

                        //Se o objeto container for diferente de nulo, criar o arquivo docker-compose.yml
                        if (container is not null)
                        {
                            try
                            {
                                //Cria o arquivo docker-compose.yml com os dados do novo cliente
                                using (StreamWriter writer = File.CreateText(Path.Combine(folderCliente, "docker-compose.yml")))
                                {
                                    writer.WriteLine("version: \"3.8\"");
                                    writer.WriteLine("services:");
                                    writer.WriteLine($"  db_tenant:");
                                    writer.WriteLine($"     container_name: {container?.ContainerDbName}");
                                    writer.WriteLine($"     image: {container?.ContainerDbImage}");
                                    writer.WriteLine($"     environment:");
                                    writer.WriteLine($"         - POSTGRES_DB={container?.EnvironmentDbName}");
                                    writer.WriteLine($"         - POSTGRES_USER={container?.EnvironmentDbUser}");
                                    writer.WriteLine($"         - POSTGRES_PASSWORD={container?.EnvironmentDbPwd}");
                                    writer.WriteLine($"         - POSTGRES_HOST_AUTH_METHOD=trust");
                                    writer.WriteLine($"     ports:");
                                    writer.WriteLine($"         - {container?.ContainerDbPort}:5432");
                                    writer.WriteLine($"     volumes:");
                                    writer.WriteLine($"         - {container?.ContainerDbVolume}:/var/lib/postgresql/data");
                                    writer.WriteLine($"     restart: always");
                                    writer.WriteLine($"     networks:");
                                    writer.WriteLine($"         - {container?.ContainerDbNetwork}");
                                    writer.WriteLine("volumes:");
                                    writer.WriteLine($"  {container?.ContainerDbVolume}:");
                                    writer.WriteLine("networks:");
                                    writer.WriteLine($"  {container?.ContainerDbNetwork}:");
                                }

                                await Task.Delay(1000);

                                //Define a pasta do cliente como corrente
                                Directory.SetCurrentDirectory(folderCliente);

                                //Copia a bat que vai ser usada para executar o comando "docker-compose up -d"
                                File.Copy(Path.Combine(folder, "DockerComposeUp.bat"), Path.Combine(folderCliente, "DockerComposeUp.bat"));

                                //Configura o comando a ser executado na linha de comando do console
                                ProcessStartInfo startInfo = new ProcessStartInfo
                                {
                                    FileName = ".\\DockerComposeUp.bat",
                                    UseShellExecute = true // Define como true para abrir em uma nova janela de comando
                                };

                                // Executa a criação do container
                                Process.Start(startInfo);

                                await Task.Delay(2000);

                                //Remove o folder e arquivos da pasta do cliente
                                RemoveFolderAndFiles(folderCliente, folder);

                                container!.IsUp = true;
                                container.CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
                                container.TimedAt = TimeOnly.Parse(DateTime.Now.ToString("HH:mm:ss"));

                                await _unitOfWork.ContainerDbRepository.Update(container);
                            }
                            catch (Exception ex)
                            {
                                _logger!.LogError(ex, "Execute (1)");
                                container!.IsUp = false;
                            }
                            finally
                            {
                                if (container!.IsUp)
                                    _unitOfWork.CommitAsync().Wait();
                            }
                        }
                    }
                }

                folderCliente = string.Empty;

                //Recupera todos os registros da tabela Container, que estão 
                //com IsUp = false e IsActive = false, para então remover tais containers
                IEnumerable<ContainerDb>? containersToDown = await _unitOfWork.ContainerDbRepository.GetList(x => x.IsUp == false && x.IsActive == false);

                //Caso existam registros para baixar os containers
                if (containersToDown!.Any())
                {
                    foreach (var container in containersToDown!)
                    {
                        folderCliente = Path.Combine(folder, container!.ContainerDbName! + "_down");

                        //Caso por algum motivo o folder ainda exista, remove
                        RemoveFolderAndFiles(folderCliente, folder);

                        //Recria o folder com o nome do cliente
                        Directory.CreateDirectory(folderCliente);

                        //Se o objeto container for diferente de nulo
                        if (container is not null)
                        {
                            try
                            {
                                //Define a pasta do cliente como corrente
                                Directory.SetCurrentDirectory(folderCliente);

                                //Copia a bat que vai ser usada para executar o comando "docker stop <container-id or container-name>"
                                File.Copy(Path.Combine(folder, "DockerComposeDown.bat"), Path.Combine(folderCliente, "DockerComposeDown.bat"));

                                string batFilePath = Path.Combine(folderCliente, "DockerComposeDown.bat");
                                string dockerCommand = $"docker stop {container.ContainerDbName}";

                                //Abre a bat e insere a linha de comando acima
                                using (StreamWriter writer = new StreamWriter(batFilePath))
                                {
                                    writer.WriteLine(dockerCommand);
                                }

                                //Configura o comando a ser executado na linha de comando do console
                                ProcessStartInfo startInfo = new ProcessStartInfo
                                {
                                    FileName = ".\\DockerComposeDown.bat",
                                    UseShellExecute = true // Define como true para abrir em uma nova janela de comando
                                };

                                // Executa a derrubada do container
                                Process.Start(startInfo);

                                await Task.Delay(2000);

                                //Remove o folder e arquivos da pasta do cliente
                                RemoveFolderAndFiles(folderCliente, folder);

                                var containerPort = container.PortId;

                                //Atualiza o status do containerdb
                                container!.IsUp = false;
                                container.DeativatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
                                container.DeactivatedTimedAt = TimeOnly.Parse(DateTime.Now.ToString("HH:mm:ss"));

                                await _unitOfWork.ContainerDbRepository.Update(container);

                                //Atualiza todas as tabelas relacionadas ao container que está sendo desligado
                                var tenant = await _unitOfWork.TenantRepository.GetById(container.TenantId);

                                tenant!.IsActive = false;
                                tenant.DeativatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
                                tenant.DeactivatedTimedAt = TimeOnly.Parse(DateTime.Now.ToString("HH:mm:ss"));

                                await _unitOfWork.TenantRepository.Update(tenant);

                                //Remove logicamente a porta associada ao Containerdb
                                await _unitOfWork.PortRepository.Delete(containerPort, true);

                                //Inativa todos os usuários associados ao tenant
                                var users = await _unitOfWork.UserRepository.GetList(x => x.TenantId == container.TenantId);

                                foreach (var user in users!)
                                {
                                    user.IsActive = false;
                                    await _unitOfWork.UserRepository.Update(user);
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger!.LogError(ex, "Execute (2)");
                                container!.IsUp = true;
                            }
                            finally
                            {
                                _unitOfWork.CommitAsync().Wait();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Execute (2)");
            }
        }

        private void RemoveFolderAndFiles(string folderCliente, string folder)
        {
            if (File.Exists(Path.Combine(folderCliente, "docker-compose.yml")))
            {
                File.Delete(Path.Combine(folderCliente, "docker-compose.yml"));
                File.Delete(Path.Combine(folderCliente, "DockerComposeUp.bat"));
            }

            if (File.Exists(Path.Combine(folderCliente, "DockerComposeDown.bat")))
            {
                File.Delete(Path.Combine(folderCliente, "DockerComposeDown.bat"));
            }

            Directory.SetCurrentDirectory(folder);

            //Apaga o diretorio se existir
            if (Directory.Exists(folderCliente))
            {
                Directory.Delete(folderCliente);
            }
        }
    }
}
