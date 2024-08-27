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
	[Route("api/ContainerDb")]
	[SwaggerTag("ContainerDb")]
	[ApiController]
	public class ContainerDbController : Base.ControllerBase, IControllerBasic<ContainerDbRequest>
	{
		private readonly ILogger<ContainerDbController>? _logger;

		public ContainerDbController(IUnitOfWork unitOfWork,
					IMapper? mapper,
					IConfiguration configuration,
					ILogger<ContainerDbController>? logger)
			: base(unitOfWork, mapper, configuration)
		{
			_nomeEntidade = "ContainerDb";
			_logger = logger;
		}

		[HttpGet]
		[Route(nameof(GetAll))]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(ContainerDbResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(ContainerDbResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<ContainerDbResponse>.Error("Usuário não autorizado!"));
				}

				var list = await _unitOfWork!.ContainerDbRepository.GetAll();

				var responseList = _mapper!.Map<IEnumerable<ContainerDb>, IEnumerable<ContainerDbResponse>>(list!);

				return Ok(ResponseFactory<IEnumerable<ContainerDbResponse>>.Success("Lista de " + _nomeEntidade + " recuperada com sucesso.", responseList));
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "GetAll");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error("Erro ao recuperar lista " + _nomeEntidade + " - " + ex.Message));
			}
		}

		[HttpGet]
		[Route("GetById/{id:Guid}")]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> GetById(Guid id)
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<ContainerDbResponse>.Error("Usuário não autorizado!"));
				}

				if (!Guid.TryParse(id.ToString(), out _))
				{
						_logger!.LogWarning("Id inválido!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error("Id inválido!"));
				}

				var entity = await _unitOfWork!.ContainerDbRepository.GetById(id);

				if (entity == null)
				{
					_logger!.LogWarning("Não existe ContainerDb com o Id informado!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error("Não existe ContainerDb com o Id informado!"));
				}

				var response = _mapper!.Map<ContainerDb, ContainerDbResponse>(entity!);

				return Ok(ResponseFactory<ContainerDbResponse>.Success("Consulta realizada com sucesso.", response));
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "GetById");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Erro ao recuperar configuração - ", _nomeEntidade) + ex.Message));
			}
		}

		[HttpPost]
		[Route(nameof(Insert))]
		[Consumes("application/json")]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> Insert([FromBody] ContainerDbRequest request)
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<ContainerDbResponse>.Error("Usuário não autorizado!"));
				}

				if (request is null)
				{
					_logger!.LogWarning("Request inválido!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error("Request inválido!"));
				}

				var entity = _mapper!.Map<ContainerDb>(request);

				var result = await _unitOfWork!.ContainerDbRepository.Insert(entity);

				_unitOfWork!.CommitAsync().Wait();

				if (result != null)
				{
					var response = _mapper.Map<ContainerDbResponse>(entity);
					return Ok(ResponseFactory<ContainerDbResponse>.Success(string.Format("Inclusão de 0 Realizado Com Sucesso.", _nomeEntidade), response));
				}
				else
				{
					_logger!.LogWarning(string.Format("Não foi possível incluir o {0}! Verifique os dados enviados.", _nomeEntidade));
					return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Não foi possível incluir o 0! Verifique os dados enviados.", _nomeEntidade)));
				}
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "Insert");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Erro ao inserir o 0 - ", _nomeEntidade) + ex.Message));
			}
		}

		[HttpPut]
		[Route(nameof(Update))]
		[Consumes("application/json")]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status304NotModified, Type = typeof(ContainerDbResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(ContainerDbResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> Update([FromBody] ContainerDbRequest request)
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<ContainerDbResponse>.Error("Usuário não autorizado!"));
				}

				if (request is null || !Guid.TryParse(request.Id.ToString(), out _))
				{
					_logger!.LogWarning("Id informado inválido!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error("Id informado inválido!"));
				}

				var entity = _unitOfWork!.ContainerDbRepository.GetById(request.Id).Result;

				if (entity is null)
				{
					_logger!.LogWarning("Id informado inválido!");
					return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error("Id informado inválido!"));
				}

				_mapper!.Map(request, entity);

				var result = await _unitOfWork!.ContainerDbRepository.Update(entity);

				_unitOfWork!.CommitAsync().Wait();

				if (result)
				{
					var response = _mapper!.Map<ContainerDbResponse>(entity);
					return Ok(ResponseFactory<ContainerDbResponse>.Success(string.Format("Atualização do 0 realizada com sucesso.", _nomeEntidade), response));
				}
				else
				{
					_logger!.LogWarning(string.Format("{0} não encontrado para atualização!", _nomeEntidade));
					return StatusCode(StatusCodes.Status304NotModified, ResponseFactory<ContainerDbResponse>.Error(string.Format("0 não encontrado para atualização!", _nomeEntidade)));
				}
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "Update");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Erro ao atualizar a 0 - ", _nomeEntidade) + ex.Message));
			}
		}

		[HttpDelete]
		[Route(nameof(Delete))]
		[Produces("application/json")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(ContainerDbResponse))]
		[ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
		[Authorize(Roles = "Administrador")]
		public async Task<IActionResult> Delete(Guid id)
		{
			try
			{
				if (!IsUserClaimsValid())
				{
					_logger!.LogWarning("Usuário não autorizado!");
					return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<ContainerDbResponse>.Error("Usuário não autorizado!"));
				}

				if (id.ToString().Length == 0)
				{
					_logger!.LogWarning("Id informado igual a 0!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error("Id informado igual a 0!"));
				}

				var entity = _unitOfWork!.ContainerDbRepository.GetById(id).Result;

				if (entity is null)
				{
					_logger!.LogWarning("Id informado inválido!");
					return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error("Id informado inválido!"));
				}

				var result = await _unitOfWork!.ContainerDbRepository.Delete(id, true);

				_unitOfWork!.CommitAsync().Wait();

				if (result)
				{
					var response = _mapper!.Map<ContainerDbResponse>(entity);
					return Ok(ResponseFactory<ContainerDbResponse>.Success(string.Format("Remoção de 0 realizada com sucesso.", _nomeEntidade), response));
				}
				else
				{
					_logger!.LogWarning(string.Format("{0} não encontrada para remoção!", _nomeEntidade));
					return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error(string.Format("0 não encontrada para remoção!", _nomeEntidade)));
				}
			}
			catch (Exception ex)
			{
				_logger!.LogError(ex, "Delete");
				return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Erro ao remover a 0 - ", _nomeEntidade) + ex.Message));
			}
		}

		[NonAction]
		public Task<IActionResult> GetAllPaged(ContainerDbRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
