using AtendimentoMultiTenant.Core.ManagementArea.Entities;
using AtendimentoMultiTenant.Api.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Core.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using Microsoft.AspNetCore.Authorization;

namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers
{
	[Route("api/LogAccess")]
	[SwaggerTag("LogAccess")]
	[ApiController]
	public class LogAccessController : Base.ControllerBase, IControllerFull<LogAccessRequest, LogAccessPagedRequest>
	{
		private readonly ILogger<LogAccessController>? _logger;

		public LogAccessController(IUnitOfWork unitOfWork,
					IMapper? mapper,
					IConfiguration configuration,
					ILogger<LogAccessController>? logger)
			: base(unitOfWork, mapper, configuration)
		{
			_nomeEntidade = "LogAccess";
			_logger = logger;
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

				var list = await _unitOfWork!.LogAccessRepository.GetAll();

				var responseList = _mapper!.Map<IEnumerable<LogAccess>, IEnumerable<LogAccessResponse>>(list!);

				return Ok(ResponseFactory<IEnumerable<LogAccessResponse>>.Success("Lista de " + _nomeEntidade + " recuperada com sucesso.", responseList));
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "GetAll");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<LogAccessResponse>.Error("Erro ao recuperar lista " + _nomeEntidade + " - " + ex.Message));
			}
		}

		[NonAction]
		public Task<IActionResult> GetAllPaged(LogAccessRequest request)
		{
			throw new NotImplementedException();
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

		[NonAction]
		public Task<IActionResult> GetAll([FromBody] LogAccessPagedRequest request)
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
