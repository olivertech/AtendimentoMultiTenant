namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers
{
    [Route("api/Menu")]
    [SwaggerTag("Menu")]
    [ApiController]
    public class MenuController : Base.ControllerBase, IController<MenuRequest, MenuPagedRequest>
    {
        private readonly IPortFinder _portFinder;
        private readonly ILogger<ConfigurationController>? _logger;
        private readonly IValidator<ContainerDbRequest>? _containerDbRequestValidator;

        public MenuController(IUnitOfWork unitOfWork,
                              IMapper? mapper,
                              IConfiguration configuration,
                              IPortFinder portFinder,
                              ILogger<ConfigurationController>? logger,
                              IValidator<ContainerDbRequest> containerDbRequestValidator)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Container";
            _portFinder = portFinder;
            _logger = logger;
            _containerDbRequestValidator = containerDbRequestValidator;
        }

        [NonAction]
        public Task<IActionResult> GetAll([FromBody] MenuPagedRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(MenuResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<MenuResponse>.Error(false, "Usuário não autorizado!"));
                }

                var list = await _unitOfWork!.MenuRepository.GetAllFull();

                var responseList = _mapper!.Map<IEnumerable<Menu>, IEnumerable<MenuResponse>>(list!);

                return Ok(ResponseFactory<IEnumerable<MenuResponse>>.Success(true, "Lista recuperada com sucesso.", responseList));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<MenuResponse>.Error(false, string.Format("Erro ao listar menus - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpGet]
        [Route("Get/{id:Guid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(MenuResponse))]
        [Authorize(Roles = "Administrador")]
        public Task<IActionResult> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(nameof(GetCount))]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        public Task<IActionResult> GetCount()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(nameof(GetListByName))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(MenuResponse))]
        [Authorize(Roles = "Administrador")]
        public Task<IActionResult> GetListByName(string name)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route(nameof(Insert))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(MenuResponse))]
        [Authorize(Roles = "Administrador")]
        public Task<IActionResult> Insert([FromBody] MenuRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route(nameof(Update))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status304NotModified, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(MenuResponse))]
        [Authorize(Roles = "Administrador")]
        public Task<IActionResult> Update(MenuRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(MenuResponse))]
        [Authorize(Roles = "Administrador")]
        public Task<IActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
