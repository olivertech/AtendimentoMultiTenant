namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers
{
    [Route("api/LogAccess")]
    [SwaggerTag("LogAccess")]
    [ApiController]
    public class LogAccessController : Base.ControllerBase, IControllerBasic<LogAccessRequest>
    {
        private readonly ILogger<ConfigurationController>? _logger;
        private readonly IValidator<LogAccessRequest>? _requestValidator;

        public LogAccessController(IUnitOfWork unitOfWork,
                                       IMapper? mapper,
                                       IConfiguration configuration,
                                       ILogger<ConfigurationController>? logger,
                                       IValidator<LogAccessRequest> requestValidator)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Container";
            _logger = logger;
            _requestValidator = requestValidator;
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
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<LogAccessResponse>.Error(false, "Usuário não autorizado!"));
                }

                var list = await _unitOfWork!.LogAccessRepository.GetAll();
                var responseList = _mapper!.Map<IEnumerable<LogAccess>, IEnumerable<LogAccessResponse>>(list!);

                return Ok(ResponseFactory<IEnumerable<LogAccessResponse>>.Success(true, "Lista recuperada com sucesso.", responseList));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<LogAccessResponse>.Error(false, string.Format("Erro ao listar menus - ", _nomeEntidade) + ex.Message));
            }
        }

        [NonAction]
        public Task<IActionResult> GetById(Guid id)
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
