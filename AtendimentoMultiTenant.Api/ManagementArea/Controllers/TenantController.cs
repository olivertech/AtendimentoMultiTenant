namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers
{
	[Route("api/Tenant")]
	[SwaggerTag("Tenant")]
	[ApiController]
	public class TenantController : Base.ControllerBase, IControllerFull<TenantRequest, TenantPagedRequest>
	{
		private readonly ILogger<TenantController>? _logger;

		public TenantController(IUnitOfWork unitOfWork,
					IMapper? mapper,
					IConfiguration configuration,
					ILogger<TenantController>? logger)
			: base(unitOfWork, mapper, configuration)
		{
			_nomeEntidade = "Tenant";
			_logger = logger;
		}

		[NonAction]
		public Task<IActionResult> GetAll()
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetAllPaged(TenantRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Insert([FromBody] TenantRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Update(TenantRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetAll([FromBody] TenantPagedRequest request)
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
