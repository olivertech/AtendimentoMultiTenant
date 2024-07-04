using AtendimentoMultiTenant.Core.Interfaces;
using System.Diagnostics;

namespace AtendimentoMultiTenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        protected readonly IConfiguration? _configuration;
        protected readonly IContainerRepository _containerRepository;

        public HomeController(IConfiguration configuration,
                              IContainerRepository containerRepository)
        {
            _configuration = configuration;
            _containerRepository = containerRepository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Route(nameof(GerarDockerCompose))]
        [Produces("application/json")]
        public string GerarDockerCompose()
        {

            //AQUI VAI VIR A LOGICA DE CRIAR O REGISTRO NO BANCO... O QUE NO MOMENTO ESTÁ SENDO FEITO VIA SEED

            return "Banco de dados gerado com sucesso.";

            //string folder = _configuration!.GetSection("PastaDockerComposes").Value!;

            //var container = await _containerRepository.GetById(Guid.Parse("f6a2372a-b146-45f9-be70-a0be13736dd8"));

            //string folderCliente = Path.Combine(folder, container!.ContainerName!);

            //RemoveFolderAndFiles(folderCliente, folder);

            //Recria o diretorio
            //Directory.CreateDirectory(folderCliente);

            //version: "3.8"
            //services:
            //  db_data:
            //       container_name: postgresql_tenants
            //       image: postgres: 16.2
            //       environment:
            //          - POSTGRES_DB = AtendimentoTenantDB
            //          - POSTGRES_USER = postgrestenantuser
            //          - POSTGRES_PASSWORD = atendimento@tenant
            //          - POSTGRES_HOST_AUTH_METHOD = trust
            //       ports:
            //          -5433:5432
            //       volumes:
            //          -db_tenant_volume:/var/lib/postgresql/data
            //       restart: always
            //       networks:
            //          -db_tenant_network

            //Se o objeto container for diferente de nulo, criar o arquivo docker-compose.yml
            //if (container is not null)
            //{
            //    using (StreamWriter writer = System.IO.File.CreateText(Path.Combine(folderCliente, "docker-compose.yml")))
            //    {
            //        writer.WriteLine("version: \"3.8\"");
            //        writer.WriteLine("services:");
            //        writer.WriteLine($"  db_tenant:");
            //        writer.WriteLine($"     container_name: {container?.ContainerName}");
            //        writer.WriteLine($"     image: {container?.ContainerImage}");
            //        writer.WriteLine($"     environment:");
            //        writer.WriteLine($"         - POSTGRES_DB={container?.EnvironmentDbName}");
            //        writer.WriteLine($"         - POSTGRES_USER={container?.EnvironmentDbUser}");
            //        writer.WriteLine($"         - POSTGRES_PASSWORD={container?.EnvironmentDbPwd}");
            //        writer.WriteLine($"         - POSTGRES_HOST_AUTH_METHOD=trust");
            //        writer.WriteLine($"     ports:");
            //        writer.WriteLine($"         - {container?.ContainerPort}:5432");
            //        writer.WriteLine($"     volumes:");
            //        writer.WriteLine($"         - {container?.ContainerVolume}:/var/lib/postgresql/data");
            //        writer.WriteLine($"     restart: always");
            //        writer.WriteLine($"     networks:");
            //        writer.WriteLine($"         - {container?.ContainerNetwork}");
            //        writer.WriteLine("volumes:");
            //        writer.WriteLine($"  {container?.ContainerVolume}:");
            //        writer.WriteLine("networks:");
            //        writer.WriteLine($"  {container?.ContainerNetwork}:");
            //    }

            //    await Task.Delay(1000);

            //    Directory.SetCurrentDirectory(folderCliente);

            //    System.IO.File.Copy(Path.Combine(folder, "DockerComposeUp.bat"), Path.Combine(folderCliente, "DockerComposeUp.bat"));

            //    ProcessStartInfo startInfo = new ProcessStartInfo
            //    {
            //        FileName = ".\\DockerComposeUp.bat",
            //        UseShellExecute = true // Define como true para abrir em uma nova janela de comando
            //    };

            //    try
            //    {
            //        // Executa a criação do container
            //        Process.Start(startInfo);

            //        await Task.Delay(2000);

            //        //Remove folder e arquivos
            //        RemoveFolderAndFiles(folderCliente, folder);

            //        return "Banco de dados gerado com sucesso.";


            //        //PAREI AQUI... CRIAR COLUNA BOOLEAN NA TABELA CONTAINER 
            //        //PARA INDICAR QDO UM CONTAINER JÁ FOI CRIADO COM SUCESSO,
            //        //FACILITANDO O CONTROLE DE QUAIS CONTAINERS AINDA ESTÃO 
            //        //AGUARDANDO SEREM CRIADOS E QUAIS JÁ FORAM CRIADOS COM
            //        //SUCESSO.
            //        //
            //        //PENSAR NA IDEIA DE USAR O QUARTZ.NET PRA 
            //        //PROCESSAMENTO EM PARALELO DA CRIAÇÃO DOS CONTAINERS
            //        //
            //        //CRIAR O SERVIÇO DE INSERT DE UM NOVO CONTAINER PRA PODER SIMULAR 
            //        //O PROCESSO DE CRIAÇÃO DINAMICA...
            //    }
            //    catch (Exception ex)
            //    {
            //        return "Erro ao criar banco de dados - " + ex.Message;
            //    }
            //}

            //return "Não foi possível criar o container do banco";
        }

        //private void RemoveFolderAndFiles(string folderCliente, string folder)
        //{
        //    if (System.IO.File.Exists(Path.Combine(folderCliente, "docker-compose.yml")))
        //    {
        //        System.IO.File.Delete(Path.Combine(folderCliente, "docker-compose.yml"));
        //        System.IO.File.Delete(Path.Combine(folderCliente, "DockerComposeUp.bat"));
        //    }

        //    Directory.SetCurrentDirectory(folder);

        //    //Apaga o diretorio se não existir
        //    if (Directory.Exists(folderCliente))
        //    {
        //        Directory.Delete(folderCliente);
        //    }
        //}
    }
}
