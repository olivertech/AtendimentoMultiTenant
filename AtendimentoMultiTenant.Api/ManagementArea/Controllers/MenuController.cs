namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers
{
	[Route("api/Menu")]
	[SwaggerTag("Menu")]
	[ApiController]
	public class MenuController : Base.ControllerBase, IControllerFull<MenuRequest, MenuPagedRequest>
	{
		private readonly ILogger<MenuController>? _logger;

		public MenuController(IUnitOfWork unitOfWork,
					IMapper? mapper,
					IConfiguration configuration,
					ILogger<MenuController>? logger)
			: base(unitOfWork, mapper, configuration)
		{
			_nomeEntidade = "Menu";
			_logger = logger;
		}

		[HttpGet]
		[Route(nameof(GetAll))]
		[Produces("application/json")]
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
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<MenuResponse>.Error("Usuário não autorizado!"));
				}

				var list = await _unitOfWork!.MenuRepository.GetAll();

				var responseList = _mapper!.Map<IEnumerable<Menu>, IEnumerable<MenuResponse>>(list!);

				return Ok(ResponseFactory<IEnumerable<MenuResponse>>.Success("Lista de " + _nomeEntidade + " recuperada com sucesso.", responseList));
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "GetAll");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<MenuResponse>.Error("Erro ao recuperar lista " + _nomeEntidade + " - " + ex.Message));
			}
		}

		[NonAction]
		public Task<IActionResult> GetAllPaged(MenuRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Insert([FromBody] MenuRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Update(MenuRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetAll([FromBody] MenuPagedRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetCount()
		{
			throw new NotImplementedException();
		}
	}
}
