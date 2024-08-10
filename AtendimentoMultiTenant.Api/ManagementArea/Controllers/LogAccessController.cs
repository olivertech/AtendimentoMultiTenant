using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers
{
    [Route("api/LogAccess")]
    [SwaggerTag("LogAccess")]
    [ApiController]
    public class LogAccessController : Base.ControllerBase, IControllerFull<LogAccessRequest, LogAccessPagedRequest>
    {
        private readonly ILogger<ContainerDbController>? _logger;

        public LogAccessController(IUnitOfWork unitOfWork,
                                   IMapper? mapper,
                                   IConfiguration configuration,
                                   ILogger<ContainerDbController>? logger)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Logs de Acesso";
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(GetAll))]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(LogAccessResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(LogAccessResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(LogAccessResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll([FromBody] LogAccessPagedRequest request)
        {
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<LogAccessResponse>.Error("Usuário não autorizado!"));
                }

                var list = await _unitOfWork!.LogAccessRepository.GetPagedList(request.PageSize, request.PageNumber);

                var responseList = _mapper!.Map<IEnumerable<LogAccess>, IEnumerable<LogAccessResponse>>(list!);

                return Ok(ResponsePagedFactory<IEnumerable<LogAccessResponse>>.Success($"Lista de {_nomeEntidade} recuperada com sucesso.", responseList, request.PageNumber, request.PageSize));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<LogAccessResponse>.Error($"Erro ao recuperar lista de {_nomeEntidade} - " + ex.Message));
            }
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(LogAccessResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(LogAccessResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(LogAccessResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<LogAccessResponse>.Error("Usuário não autorizado!"));
                }

                var list = await _unitOfWork!.LogAccessRepository.GetAllFull();

                var responseList = _mapper!.Map<IEnumerable<LogAccess>, IEnumerable<LogAccessResponse>>(list!);

                return Ok(ResponseFactory<IEnumerable<LogAccessResponse>>.Success($"Lista de {_nomeEntidade} recuperada com sucesso.", responseList));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<LogAccessResponse>.Error($"Erro ao recuperar lista {_nomeEntidade} - " + ex.Message));
            }
        }

        [NonAction]
        public Task<IActionResult> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public Task<IActionResult> GetCount()
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public Task<IActionResult> GetListByName(string name)
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public Task<IActionResult> Insert([FromBody] LogAccessRequest request)
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public Task<IActionResult> Update(LogAccessRequest request)
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public Task<IActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
