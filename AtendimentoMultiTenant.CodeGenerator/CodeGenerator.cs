using Microsoft.EntityFrameworkCore.Metadata;
using System.Text;

namespace AtendimentoMultiTenant.CodeGenerator
{
    public class CodeGenerators
    {        
        private readonly string projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));

        #region 1 - Web
        public void GenerateRazorPages(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {

        }

        public void GenerateRazorPagesCs(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {

        }

        public void GenerateRazorHandlers(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {

        }

        public void GenerateRazorHandlerInterfaces(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {

        }

        #endregion

        #region 2 - Api
        public void GenerateControllers(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {

        }

        #endregion

        #region 3 - Infra
        public void GenerateRepositories(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {
            if (!Directory.Exists($"{projectPath}\\Repositories"))
                Directory.CreateDirectory($"{projectPath}\\Repositories");

            foreach (var entity in entityTypes!)
            {
                var entityName = entity.ClrType.Name;

                if (!ignoreList.Contains(entityName))
                {
                    var repositoryName = $"{entityName}Repository";

                    var sb = new StringBuilder();

                    sb.AppendLine("using AtendimentoMultiTenant.Core.ManagementArea.Entities;");
                    sb.AppendLine("using AtendimentoMultiTenant.Core.ManagementArea.Interfaces;");
                    sb.AppendLine("using AtendimentoMultiTenant.Infra.ManagementArea.Context;");
                    sb.AppendLine("using AtendimentoMultiTenant.Infra.ManagementArea.Repositories.Base;");
                    sb.AppendLine("using System.Diagnostics.CodeAnalysis;");
                    sb.AppendLine();
                    sb.AppendLine("namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories");
                    sb.AppendLine("{");
                    sb.AppendLine($"\tpublic class {repositoryName} : RepositoryConfigurationBase<{entityName}>, I{entityName}Repository");
                    sb.AppendLine("\t{");
                    sb.AppendLine($"\t\tpublic {repositoryName}([NotNull] ManagementAreaDbContext context) : base(context)");
                    sb.AppendLine("\t\t{}");
                    sb.AppendLine("\t}");
                    sb.AppendLine("}");

                    if (File.Exists($"{projectPath}\\Repositories\\{repositoryName}.cs"))
                        File.Delete($"{projectPath}\\Repositories\\{repositoryName}.cs");

                    File.WriteAllText($"{projectPath}\\Repositories\\{repositoryName}.cs", sb.ToString());
                }
            }
        }

        #endregion

        #region 4 - Core
        /// <summary>
        /// Método que cria as interfaces dos repositorios
        /// </summary>
        public void GenerateRepositoryInterfaces(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {
            if (!Directory.Exists($"{projectPath}\\Interfaces"))
                Directory.CreateDirectory($"{projectPath}\\Interfaces");

            foreach (var entity in entityTypes!)
            {
                var entityName = entity.ClrType.Name;

                if (!ignoreList.Contains(entityName))
                {
                    var interfaceName = $"I{entityName}Repository";

                    var sb = new StringBuilder();

                    sb.AppendLine("using AtendimentoMultiTenant.Core.ManagementArea.Entities;");
                    sb.AppendLine("using AtendimentoMultiTenant.Core.ManagementArea.Interfaces.Base;");
                    sb.AppendLine();
                    sb.AppendLine("namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces");
                    sb.AppendLine("{");
                    sb.AppendLine($"\tpublic interface {interfaceName} : IRepositoryConfigurationBase<{entityName}>");
                    sb.AppendLine("\t{}");
                    sb.AppendLine("}");

                    if (File.Exists($"{projectPath}\\Interfaces\\{interfaceName}.cs"))
                        File.Delete($"{projectPath}\\Interfaces\\{interfaceName}.cs");

                    File.WriteAllText($"{projectPath}\\Interfaces\\{interfaceName}.cs", sb.ToString());
                }
            }
        }

        #endregion

        #region 5 - Shared
        public void GenerateRequests(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {

        }

        public void GeneratePagedRequests(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {

        }

        public void GenerateResponses(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {

        }

        #endregion
    }
}
