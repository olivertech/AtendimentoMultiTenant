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
	[Route("api/Feature")]
	[SwaggerTag("Feature")]
	[ApiController]
	public class FeatureController : Base.ControllerBase, IControllerFull<FeatureRequest, FeaturePagedRequest>
	{
		private readonly ILogger<FeatureController>? _logger;

		public FeatureController(IUnitOfWork unitOfWork,
					IMapper? mapper,
					IConfiguration configuration,
					ILogger<FeatureController>? logger)
			: base(unitOfWork, mapper, configuration)
		{
			_nomeEntidade = "Feature";
			_logger = logger;
		}

		[HttpGet]
		[Route(nameof(GetAll))]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(FeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(FeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(FeatureResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<FeatureResponse>.Error("Usuário não autorizado!"));
				}

				var list = await _unitOfWork!.FeatureRepository.GetAll();

				var responseList = _mapper!.Map<IEnumerable<Feature>, IEnumerable<FeatureResponse>>(list!);

				return Ok(ResponseFactory<IEnumerable<FeatureResponse>>.Success("Lista de " + _nomeEntidade + " recuperada com sucesso.", responseList));
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "GetAll");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<FeatureResponse>.Error("Erro ao recuperar lista " + _nomeEntidade + " - " + ex.Message));
			}
		}

		[NonAction]
		public Task<IActionResult> GetAllPaged(FeatureRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Insert([FromBody] FeatureRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Update(FeatureRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetAll([FromBody] FeaturePagedRequest request)
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
