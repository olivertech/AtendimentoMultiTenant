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
	public class UserFeatureController : Base.ControllerBase, IControllerBasic<UserFeatureRequest>
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

		[HttpGet]
		[Route("GetById/{id:Guid}")]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(UserFeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(UserFeatureResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> GetById(Guid id)
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<UserFeatureResponse>.Error("Usuário não autorizado!"));
				}

				if (!Guid.TryParse(id.ToString(), out _))
				{
						_logger!.LogWarning("Id inválido!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<UserFeatureResponse>.Error("Id inválido!"));
				}

				var entity = await _unitOfWork!.UserFeatureRepository.GetById(id);

				if (entity == null)
				{
					_logger!.LogWarning("Não existe UserFeature com o Id informado!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<UserFeatureResponse>.Error("Não existe UserFeature com o Id informado!"));
				}

				var response = _mapper!.Map<UserFeature, UserFeatureResponse>(entity!);

				return Ok(ResponseFactory<UserFeatureResponse>.Success("Consulta realizada com sucesso.", response));
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "GetById");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<UserFeatureResponse>.Error(string.Format("Erro ao recuperar configuração - ", _nomeEntidade) + ex.Message));
			}
		}

		[HttpPost]
		[Route(nameof(Insert))]
		[Consumes("application/json")]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(UserFeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(UserFeatureResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> Insert([FromBody] UserFeatureRequest request)
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<UserFeatureResponse>.Error("Usuário não autorizado!"));
				}

				if (request is null)
				{
					_logger!.LogWarning("Request inválido!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<UserFeatureResponse>.Error("Request inválido!"));
				}

				var entity = _mapper!.Map<UserFeature>(request);

				var result = await _unitOfWork!.UserFeatureRepository.Insert(entity);

				_unitOfWork!.CommitAsync().Wait();

				if (result != null)
				{
					var response = _mapper.Map<UserFeatureResponse>(entity);
					return Ok(ResponseFactory<UserFeatureResponse>.Success(string.Format("Inclusão de 0 Realizado Com Sucesso.", _nomeEntidade), response));
				}
				else
				{
					_logger!.LogWarning(string.Format("Não foi possível incluir o {0}! Verifique os dados enviados.", _nomeEntidade));
					return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<UserFeatureResponse>.Error(string.Format("Não foi possível incluir o 0! Verifique os dados enviados.", _nomeEntidade)));
				}
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "Insert");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<UserFeatureResponse>.Error(string.Format("Erro ao inserir o 0 - ", _nomeEntidade) + ex.Message));
			}
		}

		[HttpPut]
		[Route(nameof(Update))]
		[Consumes("application/json")]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(UserFeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status304NotModified, Type = typeof(UserFeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(UserFeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(UserFeatureResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> Update([FromBody] UserFeatureRequest request)
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<UserFeatureResponse>.Error("Usuário não autorizado!"));
				}

				if (request is null || !Guid.TryParse(request.Id.ToString(), out _))
				{
					_logger!.LogWarning("Id informado inválido!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<UserFeatureResponse>.Error("Id informado inválido!"));
				}

				var entity = _unitOfWork!.UserFeatureRepository.GetById(request.Id).Result;

				if (entity is null)
				{
					_logger!.LogWarning("Id informado inválido!");
					return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<UserFeatureResponse>.Error("Id informado inválido!"));
				}

				_mapper!.Map(request, entity);

				var result = await _unitOfWork!.UserFeatureRepository.Update(entity);

				_unitOfWork!.CommitAsync().Wait();

				if (result)
				{
					var response = _mapper!.Map<UserFeatureResponse>(entity);
					return Ok(ResponseFactory<UserFeatureResponse>.Success(string.Format("Atualização do 0 realizada com sucesso.", _nomeEntidade), response));
				}
				else
				{
					_logger!.LogWarning(string.Format("{0} não encontrado para atualização!", _nomeEntidade));
					return StatusCode(StatusCodes.Status304NotModified, ResponseFactory<UserFeatureResponse>.Error(string.Format("0 não encontrado para atualização!", _nomeEntidade)));
				}
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "Update");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<UserFeatureResponse>.Error(string.Format("Erro ao atualizar a 0 - ", _nomeEntidade) + ex.Message));
			}
		}

		[HttpDelete]
		[Route(nameof(Delete))]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(UserFeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(UserFeatureResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(UserFeatureResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> Delete(Guid id)
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<UserFeatureResponse>.Error("Usuário não autorizado!"));
				}

				if (id.ToString().Length == 0)
				{
					_logger!.LogWarning("Id informado igual a 0!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<UserFeatureResponse>.Error("Id informado igual a 0!"));
				}

				var entity = _unitOfWork!.UserFeatureRepository.GetById(id).Result;

				if (entity is null)
				{
					_logger!.LogWarning("Id informado inválido!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<UserFeatureResponse>.Error("Id informado inválido!"));
				}

				var result = await _unitOfWork!.UserFeatureRepository.Delete(id, true);

				_unitOfWork!.CommitAsync().Wait();

				if (result)
				{
					var response = _mapper!.Map<UserFeatureResponse>(entity);
					return Ok(ResponseFactory<UserFeatureResponse>.Success(string.Format("Remoção de 0 realizada com sucesso.", _nomeEntidade), response));
				}
				else
				{
					_logger!.LogWarning(string.Format("{0} não encontrada para remoção!", _nomeEntidade));
					return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<UserFeatureResponse>.Error(string.Format("0 não encontrada para remoção!", _nomeEntidade)));
				}
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "Delete");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<UserFeatureResponse>.Error(string.Format("Erro ao remover a 0 - ", _nomeEntidade) + ex.Message));
			}
		}

		[NonAction]
		public Task<IActionResult> GetAllPaged(UserFeatureRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
