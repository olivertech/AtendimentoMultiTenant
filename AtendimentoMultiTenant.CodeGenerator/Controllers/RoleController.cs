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
	[Route("api/Role")]
	[SwaggerTag("Role")]
	[ApiController]
	public class RoleController : Base.ControllerBase, IControllerFull<RoleRequest, RolePagedRequest>
	{
		private readonly ILogger<RoleController>? _logger;

		public RoleController(IUnitOfWork unitOfWork,
					IMapper? mapper,
					IConfiguration configuration,
					ILogger<RoleController>? logger)
			: base(unitOfWork, mapper, configuration)
		{
			_nomeEntidade = "Role";
			_logger = logger;
		}

		[HttpGet]
		[Route(nameof(GetAll))]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(RoleResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(RoleResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(RoleResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<RoleResponse>.Error("Usuário não autorizado!"));
				}

				var list = await _unitOfWork!.RoleRepository.GetAll();

				var responseList = _mapper!.Map<IEnumerable<Role>, IEnumerable<RoleResponse>>(list!);

				return Ok(ResponseFactory<IEnumerable<RoleResponse>>.Success("Lista de " + _nomeEntidade + " recuperada com sucesso.", responseList));
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "GetAll");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<RoleResponse>.Error("Erro ao recuperar lista " + _nomeEntidade + " - " + ex.Message));
			}
		}

		[NonAction]
		public Task<IActionResult> GetAllPaged(RoleRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Insert([FromBody] RoleRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Update(RoleRequest request)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public Task<IActionResult> GetAll([FromBody] RolePagedRequest request)
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
