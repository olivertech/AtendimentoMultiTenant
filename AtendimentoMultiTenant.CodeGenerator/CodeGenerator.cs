using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            if (!Directory.Exists($"{projectPath}\\Handlers"))
                Directory.CreateDirectory($"{projectPath}\\Handlers");

            foreach (var entity in entityTypes!)
            {
                var entityName = entity.ClrType.Name;

                if (!ignoreList.Contains(entityName))
                {
                    var handlerName = $"{entityName}Handler";

                    var sb = new StringBuilder();

                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Requests;");
                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Responses;");
                    sb.AppendLine("using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;");
                    sb.AppendLine("using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;");
                    sb.AppendLine("using AtendimentoMultiTenant.Web.CommonArea.Interfaces;");
                    sb.AppendLine("using Newtonsoft.Json;");
                    sb.AppendLine("using System.Net.Http.Headers;");
                    sb.AppendLine();
                    sb.AppendLine($"namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.{entityName}.List");
                    sb.AppendLine("{");
                    sb.AppendLine($"\tpublic class {entityName}Handler : HandlerBase, IHandler<{entityName}Request, {entityName}PagedRequest, {entityName}Response>, I{entityName}Handler");
                    sb.AppendLine("\t{");
                    sb.AppendLine($"\t\tpublic {entityName}Handler(IHttpClientFactory httpClientFactory, IStorageService storageService)");
                    sb.AppendLine("\t\t\t: base(httpClientFactory, storageService)");
                    sb.AppendLine("\t\t{}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\tpublic async Task<ResponseFactory<IEnumerable<{entityName}Response>>> GetAll()");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine($"\t\t\tResponseFactory<IEnumerable<{entityName}Response>?>? result = new()!;");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\ttry");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine($"\t\t\t\tvar requestMessage = new HttpRequestMessage(HttpMethod.Get, \"Api/{entityName}/GetAll\");");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\trequestMessage.Headers.Authorization = new AuthenticationHeaderValue(\"Bearer\", await GetToken());");
                    sb.AppendLine("\t\t\t\trequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(\"application/json\"));");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tvar response = await _httpClient.SendAsync(requestMessage);");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (response.IsSuccessStatusCode)");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine($"\t\t\t\t\tresult = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<{entityName}Response>?>?>(response.Content.ReadAsStringAsync().Result);");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t\tcatch (Exception)");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\treturn new();");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\treturn result!;");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\tpublic Task<ResponsePagedFactory<IEnumerable<{entityName}Response>>> GetAll({entityName}PagedRequest request)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\tthrow new NotImplementedException();");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\tpublic Task<ResponseFactory<{entityName}Response>> GetById(Guid id)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\tthrow new NotImplementedException();");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\tpublic Task<int> GetCount()");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\tthrow new NotImplementedException();");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\tpublic Task<ResponseFactory<IEnumerable<{entityName}Response>>> GetListByName(string name)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\tthrow new NotImplementedException();");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\tpublic Task<ResponseFactory<{entityName}Response>> Insert({entityName}Request request)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\tthrow new NotImplementedException();");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\tpublic Task<ResponseFactory<{entityName}Response>> Update({entityName}Request request)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\tthrow new NotImplementedException();");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\tpublic Task<ResponseFactory<{entityName}Response>> Delete(Guid id)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\tthrow new NotImplementedException();");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine("\t}");
                    sb.AppendLine("}");

                    if (File.Exists($"{projectPath}\\Handlers\\{handlerName}.cs"))
                        File.Delete($"{projectPath}\\Handlers\\{handlerName}.cs");

                    File.WriteAllText($"{projectPath}\\Handlers\\{handlerName}.cs", sb.ToString());
                }
            }
        }

        public void GenerateRazorHandlerInterfaces(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {
            if (!Directory.Exists($"{projectPath}\\HandlerInterfaces"))
                Directory.CreateDirectory($"{projectPath}\\HandlerInterfaces");

            foreach (var entity in entityTypes!)
            {
                var entityName = entity.ClrType.Name;

                if (!ignoreList.Contains(entityName))
                {
                    var interfaceName = $"I{entityName}Handler";

                    var sb = new StringBuilder();

                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Requests;");
                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Responses;");
                    sb.AppendLine("using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;");
                    sb.AppendLine();
                    sb.AppendLine($"namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.{entityName}.List");
                    sb.AppendLine("{");
                    sb.AppendLine($"\tpublic interface I{entityName}Handler : IHandler<{entityName}Request, {entityName}PagedRequest, {entityName}Response>");
                    sb.AppendLine("\t{}");
                    sb.AppendLine("}");

                    if (File.Exists($"{projectPath}\\HandlerInterfaces\\{interfaceName}.cs"))
                        File.Delete($"{projectPath}\\HandlerInterfaces\\{interfaceName}.cs");

                    File.WriteAllText($"{projectPath}\\HandlerInterfaces\\{interfaceName}.cs", sb.ToString());
                }
            }
        }

        #endregion

        #region 2 - Api
        public void GenerateControllers(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {
            if (!Directory.Exists($"{projectPath}\\Controllers"))
                Directory.CreateDirectory($"{projectPath}\\Controllers");

            foreach (var entity in entityTypes!)
            {
                var entityName = entity.ClrType.Name;

                if (!ignoreList.Contains(entityName))
                {
                    var controllerName = $"{entityName}Controller";

                    var sb = new StringBuilder();

                    sb.AppendLine("using AtendimentoMultiTenant.Core.ManagementArea.Entities;");
                    sb.AppendLine("using AtendimentoMultiTenant.Api.ManagementArea.Interfaces;");
                    sb.AppendLine("using AtendimentoMultiTenant.Core.ManagementArea.Interfaces;");
                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Requests;");
                    sb.AppendLine("using AutoMapper;");
                    sb.AppendLine("using Microsoft.AspNetCore.Mvc;");
                    sb.AppendLine("using Microsoft.Extensions.Configuration;");
                    sb.AppendLine("using Microsoft.Extensions.Logging;");
                    sb.AppendLine("using Swashbuckle.AspNetCore.Annotations;");
                    sb.AppendLine("using Microsoft.AspNetCore.Http;");
                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Responses;");
                    sb.AppendLine("using Microsoft.AspNetCore.Authorization;");
                    sb.AppendLine();
                    sb.AppendLine("namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers");
                    sb.AppendLine("{");
                    sb.AppendLine($"\t[Route(\"api/{entityName}\")]");
                    sb.AppendLine($"\t[SwaggerTag(\"{entityName}\")]");
                    sb.AppendLine("\t[ApiController]");
                    sb.AppendLine($"\tpublic class {controllerName} : Base.ControllerBase, IControllerBasic<{entityName}Request>");
                    sb.AppendLine("\t{");
                    sb.AppendLine($"\t\tprivate readonly ILogger<{entityName}Controller>? _logger;");
                    sb.AppendLine();
                    sb.AppendLine($"\t\tpublic {controllerName}(IUnitOfWork unitOfWork,");
                    sb.AppendLine("\t\t\t\t\tIMapper? mapper,");
                    sb.AppendLine("\t\t\t\t\tIConfiguration configuration,");
                    sb.AppendLine($"\t\t\t\t\tILogger<{entityName}Controller>? logger)");
                    sb.AppendLine($"\t\t\t: base(unitOfWork, mapper, configuration)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine($"\t\t\t_nomeEntidade = \"{entityName}\";");
                    sb.AppendLine($"\t\t\t_logger = logger;");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t[HttpGet]");
                    sb.AppendLine("\t\t[Route(nameof(GetAll))]");
                    sb.AppendLine("\t\t[Produces(\"application/json\")]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof({entityName}Response))]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof({entityName}Response))]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof({entityName}Response))]");
                    sb.AppendLine("\t\t[Authorize(Roles = \"Administrador\")]");
                    sb.AppendLine("\t\tpublic async Task<IActionResult> GetAll()");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\ttry");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\tif (!IsUserClaimsValid())");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(\"Usuário não autorizado!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<{entityName}Response>.Error(\"Usuário não autorizado!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\tvar list = await _unitOfWork!.{entityName}Repository.GetAll();");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\tvar responseList = _mapper!.Map<IEnumerable<{entityName}>, IEnumerable<{entityName}Response>>(list!);");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\treturn Ok(ResponseFactory<IEnumerable<{entityName}Response>>.Success(\"Lista de \" + _nomeEntidade + \" recuperada com sucesso.\", responseList));");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t\tcatch (Exception ex)");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\t_logger!.LogError(ex, \"GetAll\");");
                    sb.AppendLine($"\t\t\t\treturn StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<{entityName}Response>.Error(\"Erro ao recuperar lista \" + _nomeEntidade + \" - \" + ex.Message));");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t[HttpGet]");
                    sb.AppendLine("\t\t[Route(\"GetById/{id:Guid}\")]");
                    sb.AppendLine("\t\t[Produces(\"application/json\")]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof({entityName}Response))]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof({entityName}Response))]");
                    sb.AppendLine("\t\t[Authorize(Roles = \"Administrador\")]");
                    sb.AppendLine("\t\tpublic async Task<IActionResult> GetById(Guid id)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\ttry");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\tif (!IsUserClaimsValid())");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(\"Usuário não autorizado!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<{entityName}Response>.Error(\"Usuário não autorizado!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (!Guid.TryParse(id.ToString(), out _))");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t\t_logger!.LogWarning(\"Id inválido!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<{entityName}Response>.Error(\"Id inválido!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\tvar entity = await _unitOfWork!.{entityName}Repository.GetById(id);");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (entity == null)");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine($"\t\t\t\t\t_logger!.LogWarning(\"Não existe {entityName} com o Id informado!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<{entityName}Response>.Error(\"Não existe {entityName} com o Id informado!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\tvar response = _mapper!.Map<{entityName}, {entityName}Response>(entity!);");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\treturn Ok(ResponseFactory<{entityName}Response>.Success(\"Consulta realizada com sucesso.\", response));");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t\tcatch (Exception ex)");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\t_logger!.LogError(ex, \"GetById\");");
                    sb.AppendLine($"\t\t\t\treturn StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<{entityName}Response>.Error(string.Format(\"Erro ao recuperar configuração - \", _nomeEntidade) + ex.Message));");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t[HttpPost]");
                    sb.AppendLine("\t\t[Route(nameof(Insert))]");
                    sb.AppendLine("\t\t[Consumes(\"application/json\")]");
                    sb.AppendLine("\t\t[Produces(\"application/json\")]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof({entityName}Response))]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof({entityName}Response))]");
                    sb.AppendLine("\t\t[Authorize(Roles = \"Administrador\")]");
                    sb.AppendLine($"\t\tpublic async Task<IActionResult> Insert([FromBody] {entityName}Request request)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\ttry");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\tif (!IsUserClaimsValid())");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(\"Usuário não autorizado!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<{entityName}Response>.Error(\"Usuário não autorizado!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (request is null)");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(\"Request inválido!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<{entityName}Response>.Error(\"Request inválido!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\tvar entity = _mapper!.Map<{entityName}>(request);");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\tvar result = await _unitOfWork!.{entityName}Repository.Insert(entity);");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\t_unitOfWork!.CommitAsync().Wait();");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (result != null)");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine($"\t\t\t\t\tvar response = _mapper.Map<{entityName}Response>(entity);");
                    sb.AppendLine($"\t\t\t\t\treturn Ok(ResponseFactory<{entityName}Response>.Success(string.Format(\"Inclusão de {0} Realizado Com Sucesso.\", _nomeEntidade), response));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine("\t\t\t\telse");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(string.Format(\"Não foi possível incluir o {0}! Verifique os dados enviados.\", _nomeEntidade));");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<{entityName}Response>.Error(string.Format(\"Não foi possível incluir o {0}! Verifique os dados enviados.\", _nomeEntidade)));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t\tcatch (Exception ex)");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\t_logger!.LogError(ex, \"Insert\");");
                    sb.AppendLine($"\t\t\t\treturn StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<{entityName}Response>.Error(string.Format(\"Erro ao inserir o {0} - \", _nomeEntidade) + ex.Message));");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t[HttpPut]");
                    sb.AppendLine("\t\t[Route(nameof(Update))]");
                    sb.AppendLine("\t\t[Consumes(\"application/json\")]");
                    sb.AppendLine("\t\t[Produces(\"application/json\")]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof({entityName}Response))]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status304NotModified, Type = typeof({entityName}Response))]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof({entityName}Response))]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof({entityName}Response))]");
                    sb.AppendLine("\t\t[Authorize(Roles = \"Administrador\")]");
                    sb.AppendLine($"\t\tpublic async Task<IActionResult> Update([FromBody] {entityName}Request request)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\ttry");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\tif (!IsUserClaimsValid())");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(\"Usuário não autorizado!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<{entityName}Response>.Error(\"Usuário não autorizado!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (request is null || !Guid.TryParse(request.Id.ToString(), out _))");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(\"Id informado inválido!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<{entityName}Response>.Error(\"Id informado inválido!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\tvar entity = _unitOfWork!.{entityName}Repository.GetById(request.Id).Result;");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (entity is null)");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(\"Id informado inválido!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status404NotFound, ResponseFactory<{entityName}Response>.Error(\"Id informado inválido!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\t_mapper!.Map(request, entity);");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\tvar result = await _unitOfWork!.{entityName}Repository.Update(entity);");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\t_unitOfWork!.CommitAsync().Wait();");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (result)");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine($"\t\t\t\t\tvar response = _mapper!.Map<{entityName}Response>(entity);");
                    sb.AppendLine($"\t\t\t\t\treturn Ok(ResponseFactory<{entityName}Response>.Success(string.Format(\"Atualização do {0} realizada com sucesso.\", _nomeEntidade), response));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine("\t\t\t\telse");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(string.Format(\"{0} não encontrado para atualização!\", _nomeEntidade));");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status304NotModified, ResponseFactory<{entityName}Response>.Error(string.Format(\"{0} não encontrado para atualização!\", _nomeEntidade)));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t\tcatch (Exception ex)");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\t_logger!.LogError(ex, \"Update\");");
                    sb.AppendLine($"\t\t\t\treturn StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<{entityName}Response>.Error(string.Format(\"Erro ao atualizar a {0} - \", _nomeEntidade) + ex.Message));");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t[HttpDelete]");
                    sb.AppendLine("\t\t[Route(nameof(Delete))]");
                    sb.AppendLine("\t\t[Produces(\"application/json\")]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof({entityName}Response))]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof({entityName}Response))]");
                    sb.AppendLine($"\t\t[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof({entityName}Response))]");
                    sb.AppendLine("\t\t[Authorize(Roles = \"Administrador\")]");
                    sb.AppendLine("\t\tpublic async Task<IActionResult> Delete(Guid id)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\ttry");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\tif (!IsUserClaimsValid())");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(\"Usuário não autorizado!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<{entityName}Response>.Error(\"Usuário não autorizado!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (id.ToString().Length == 0)");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(\"Id informado igual a 0!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<{entityName}Response>.Error(\"Id informado igual a 0!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\tvar entity = _unitOfWork!.{entityName}Repository.GetById(id).Result;");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (entity is null)");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(\"Id informado inválido!\");");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<{entityName}Response>.Error(\"Id informado inválido!\"));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine();
                    sb.AppendLine($"\t\t\t\tvar result = await _unitOfWork!.{entityName}Repository.Delete(id, true);");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\t_unitOfWork!.CommitAsync().Wait();");
                    sb.AppendLine();
                    sb.AppendLine("\t\t\t\tif (result)");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine($"\t\t\t\t\tvar response = _mapper!.Map<{entityName}Response>(entity);");
                    sb.AppendLine($"\t\t\t\t\treturn Ok(ResponseFactory<{entityName}Response>.Success(string.Format(\"Remoção de {0} realizada com sucesso.\", _nomeEntidade), response));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine("\t\t\t\telse");
                    sb.AppendLine("\t\t\t\t{");
                    sb.AppendLine("\t\t\t\t\t_logger!.LogWarning(string.Format(\"{0} não encontrada para remoção!\", _nomeEntidade));");
                    sb.AppendLine($"\t\t\t\t\treturn StatusCode(StatusCodes.Status404NotFound, ResponseFactory<{entityName}Response>.Error(string.Format(\"{0} não encontrada para remoção!\", _nomeEntidade)));");
                    sb.AppendLine("\t\t\t\t}");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t\tcatch (Exception ex)");
                    sb.AppendLine("\t\t\t{");
                    sb.AppendLine("\t\t\t\t_logger!.LogError(ex, \"Delete\");");
                    sb.AppendLine($"\t\t\t\treturn StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<{entityName}Response>.Error(string.Format(\"Erro ao remover a {0} - \", _nomeEntidade) + ex.Message));");
                    sb.AppendLine("\t\t\t}");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                    sb.AppendLine("\t\t[NonAction]");
                    sb.AppendLine($"\t\tpublic Task<IActionResult> GetAllPaged({entityName}Request request)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\tthrow new NotImplementedException();");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine("\t}");
                    sb.AppendLine("}");

                    if (File.Exists($"{projectPath}\\Controllers\\{controllerName}.cs"))
                        File.Delete($"{projectPath}\\Controllers\\{controllerName}.cs");

                    File.WriteAllText($"{projectPath}\\Controllers\\{controllerName}.cs", sb.ToString());
                }
            }
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
            if (!Directory.Exists($"{projectPath}\\Requests"))
                Directory.CreateDirectory($"{projectPath}\\Requests");

            foreach (var entity in entityTypes!)
            {
                var entityName = entity.ClrType.Name;

                if (!ignoreList.Contains(entityName))
                {
                    var requestName = $"{entityName}Request";
                    var sb = new StringBuilder();
                    var properties = entity.GetProperties().OrderBy(x => x.Name);

                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;");
                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;");
                    sb.AppendLine("using Newtonsoft.Json;");
                    sb.AppendLine("using System.Text.Json.Serialization;");
                    sb.AppendLine();
                    sb.AppendLine("namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests");
                    sb.AppendLine("{");
                    sb.AppendLine($"\tpublic class {requestName} : RequestBase, IRequest");
                    sb.AppendLine("\t{");

                    foreach (var property in properties)
                    {
                        if (property.Name != "Id")
                        {
                            var type = property.ClrType.Name.Contains("Nullable") ? property.ClrType.GenericTypeArguments[0].Name : property.ClrType.Name;

                            sb.AppendLine($"\t\t[JsonPropertyName(\"{property.Name.ToLower()}\")]");
                            sb.AppendLine($"\t\t[JsonProperty(PropertyName = \"{property.Name.ToLower()}\")]");
                            sb.AppendLine($"\t\tpublic {type}? {property.Name} {{ get; set; }}");
                            sb.AppendLine();
                        }
                    }

                    sb.AppendLine("\t}");
                    sb.AppendLine("}");

                    if (File.Exists($"{projectPath}\\Requests\\{requestName}.cs"))
                        File.Delete($"{projectPath}\\Requests\\{requestName}.cs");

                    File.WriteAllText($"{projectPath}\\Requests\\{requestName}.cs", sb.ToString());
                }
            }
        }

        public void GeneratePagedRequests(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {
            if (!Directory.Exists($"{projectPath}\\PagedRequests"))
                Directory.CreateDirectory($"{projectPath}\\PagedRequests");

            foreach (var entity in entityTypes!)
            {
                var entityName = entity.ClrType.Name;

                if (!ignoreList.Contains(entityName))
                {
                    var requestPagedName = $"{entityName}PagedRequest";
                    var sb = new StringBuilder();

                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;");
                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;");
                    sb.AppendLine();
                    sb.AppendLine("namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests");
                    sb.AppendLine("{");
                    sb.AppendLine($"\tpublic class {requestPagedName} : PagedRequestBase, IRequest");
                    sb.AppendLine("\t{}");
                    sb.AppendLine("}");

                    if (File.Exists($"{projectPath}\\PagedRequests\\{requestPagedName}.cs"))
                        File.Delete($"{projectPath}\\PagedRequests\\{requestPagedName}.cs");

                    File.WriteAllText($"{projectPath}\\PagedRequests\\{requestPagedName}.cs", sb.ToString());
                }
            }
        }

        public void GenerateResponses(IEnumerable<IEntityType>? entityTypes, string[] ignoreList)
        {
            if (!Directory.Exists($"{projectPath}\\Responses"))
                Directory.CreateDirectory($"{projectPath}\\Responses");

            foreach (var entity in entityTypes!)
            {
                var entityName = entity.ClrType.Name;

                if (!ignoreList.Contains(entityName))
                {
                    var responseName = $"{entityName}Response";
                    var sb = new StringBuilder();
                    var properties = entity.GetProperties().OrderBy(x => x.Name);

                    sb.AppendLine("using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;");
                    sb.AppendLine("using Newtonsoft.Json;");
                    sb.AppendLine();
                    sb.AppendLine("namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses");
                    sb.AppendLine("{");
                    sb.AppendLine($"\tpublic class {responseName} : IResponse");
                    sb.AppendLine("\t{");

                    foreach (var property in properties)
                    {
                        var type = property.ClrType.Name.Contains("Nullable") ? property.ClrType.GenericTypeArguments[0].Name : property.ClrType.Name;

                        sb.AppendLine($"\t\t[JsonProperty(PropertyName = \"{property.Name.ToLower()}\")]");
                        sb.AppendLine($"\t\tpublic {type}? {property.Name} {{ get; set; }}");
                        sb.AppendLine();
                    }

                    sb.AppendLine("\t}");
                    sb.AppendLine("}");

                    if (File.Exists($"{projectPath}\\Responses\\{responseName}.cs"))
                        File.Delete($"{projectPath}\\Responses\\{responseName}.cs");

                    File.WriteAllText($"{projectPath}\\Responses\\{responseName}.cs", sb.ToString());
                }
            }
        }

        #endregion
    }
}
