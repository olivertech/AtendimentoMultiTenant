using AtendimentoMultiTenant.Infra.ManagementArea.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AtendimentoMultiTenant.CodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ignoreList = [""];

            DbContext? _context = new DbContextFactory().CreateDbContext([]);
            IEnumerable<IEntityType>? _entityTypes = _context!.Model.GetEntityTypes();

            var codeGenerators = new CodeGenerators();

            Console.WriteLine("****** Início do Gerador ******");
            Console.WriteLine();
            
            Console.WriteLine("1 - Generando Interfaces dos Respositórios...");
            //codeGenerators.GenerateRepositoryInterfaces(_entityTypes, ignoreList);

            Console.WriteLine("2 - Gerando Repositórios...");
            //codeGenerators.GenerateRepositories(_entityTypes, ignoreList);

            Console.WriteLine("3 - Gerando Requests...");
            //codeGenerators.GenerateRequests(_entityTypes, ignoreList);

            Console.WriteLine("4 - Gerando Paged Requests...");
            //codeGenerators.GeneratePagedRequests(_entityTypes, ignoreList);

            Console.WriteLine("5 - Gerando Responses...");
            //codeGenerators.GenerateResponses(_entityTypes, ignoreList);

            Console.WriteLine("6 - Gerando Controllers...");
            //codeGenerators.GenerateControllers(_entityTypes, ignoreList);

            Console.WriteLine("7 - Gerando Handler Interfaces...");
            codeGenerators.GenerateRazorHandlerInterfaces(_entityTypes, ignoreList);

            codeGenerators.GenerateRazorHandlers(_entityTypes, ignoreList);

            Console.WriteLine();
            Console.WriteLine("****** Fim do Gerador ******");
        }
    }
}
