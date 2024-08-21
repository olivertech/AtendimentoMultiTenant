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
	[Route("api/UserFeature")]
	[SwaggerTag("UserFeature")]
	[ApiController]
	public class UserFeatureController : Base.ControllerBase, IControllerFull<UserFeatureRequest, UserFeaturePagedRequest>
	{
		private readonly ILogger<UserFeatureController>? _logger;

		public UserFeatureController(IUnitOfWork unitOfWork,
					IMapper? mapper,
					IConfiguration configuration,
					ILogger<UserFeatureController>? logger)
			: base(unitOfWork, mapper, configuration)
		{
			_nomeEntidade = "UserFeature";
			_logger = logger;
		}

		[HttpGet]
		[Route(nameof(GetAll))]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(UserFeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(UserFeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(UserFeatureResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<UserFeatureResponse>.Error("Usuário não autorizado!"));
				}

				var list = await _unitOfWork!.UserFeatureRepository.GetAll();

				var responseList = _mapper!.Map<IEnumerable<UserFeature>, IEnumerable<UserFeatureResponse>>(list!);

				return Ok(ResponseFactory<IEnumerable<UserFeatureResponse>>.Success("Lista de " + _nomeEntidade + " recuperada com sucesso.", responseList));
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "GetAll");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<UserFeatureResponse>.Error("Erro ao recuperar lista " + _nomeEntidade + " - " + ex.Message));
			}
		}

		[NonAction]
		public Task<IActionResult> GetAllPaged(UserFeatureRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Insert([FromBody] UserFeatureRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Update(UserFeatureRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetAll([FromBody] UserFeaturePagedRequest request)
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
