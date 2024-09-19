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

        [HttpGet]
        [Route(nameof(GetAll))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(TenantResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(TenantResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(TenantResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll()
		{
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usu�rio n�o autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<TenantResponse>.Error("Usu�rio n�o autorizado!"));
                }

                var list = await _unitOfWork!.TenantRepository.GetAll(true);

                var responseList = _mapper!.Map<IEnumerable<Tenant>, IEnumerable<TenantResponse>>(list!);

                return Ok(ResponseFactory<IEnumerable<TenantResponse>>.Success("Lista de " + _nomeEntidade + " recuperada com sucesso.", responseList));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<TenantResponse>.Error("Erro ao recuperar lista " + _nomeEntidade + " - " + ex.Message));
            }
        }

		[NonAction]
		public Task<IActionResult> GetAllPaged(TenantRequest request)
		{
			throw new NotImplementedException();
		}

        [HttpGet]
        [Route("GetById/{id:Guid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(TenantResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(TenantResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetById(Guid id)
		{
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usu�rio n�o autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<TenantResponse>.Error("Usu�rio n�o autorizado!"));
                }

                if (!Guid.TryParse(id.ToString(), out _))
                {
                    _logger!.LogWarning("Id inv�lido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<TenantResponse>.Error("Id inv�lido!"));
                }

                var entity = await _unitOfWork!.TenantRepository.GetById(id);

                if (entity == null)
                {
                    _logger!.LogWarning("N�o existe tenant com o Id informado!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<TenantResponse>.Error("N�o existe tenant com o Id informado!"));
                }

                var response = _mapper!.Map<Tenant, TenantResponse>(entity!);

                return Ok(ResponseFactory<TenantResponse>.Success("Consulta realizada com sucesso.", response));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetById");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<TenantResponse>.Error(string.Format("Erro ao recuperar configura��o - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpPost]
        [Route(nameof(Insert))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(TenantResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(TenantResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Insert([FromBody] TenantRequest request)
		{
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usu�rio n�o autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<TenantResponse>.Error("Usu�rio n�o autorizado!"));
                }

                if (request is null)
                {
                    _logger!.LogWarning("Request inv�lido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<TenantResponse>.Error("Request inv�lido!"));
                }

                var entity = _mapper!.Map<Tenant>(request);

                var result = await _unitOfWork!.TenantRepository.Insert(entity);

                _unitOfWork!.CommitAsync().Wait();

                if (result != null)
                {
                    var response = _mapper.Map<TenantResponse>(entity);
                    return Ok(ResponseFactory<TenantResponse>.Success(string.Format("Inclus�o de {0} Realizado Com Sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(string.Format("N�o foi poss�vel incluir o {0}! Verifique os dados enviados.", _nomeEntidade));
                    return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<TenantResponse>.Error(string.Format("N�o foi poss�vel incluir o {0}! Verifique os dados enviados.", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Insert");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<TenantResponse>.Error(string.Format("Erro ao inserir o {0} - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpPut]
        [Route(nameof(Update))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(TenantResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status304NotModified, Type = typeof(TenantResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(TenantResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(TenantResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update(TenantRequest request)
		{
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usu�rio n�o autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<TenantResponse>.Error("Usu�rio n�o autorizado!"));
                }

                if (request is null || !Guid.TryParse(request.Id.ToString(), out _))
                {
                    _logger!.LogWarning("Id informado inv�lido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<TenantResponse>.Error("Id informado inv�lido!"));
                }

                var entity = _unitOfWork!.TenantRepository.GetById(request.Id).Result;

                if (entity is null)
                {
                    _logger!.LogWarning("Id informado inv�lido!");
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<TenantResponse>.Error("Id informado inv�lido!"));
                }

                _mapper!.Map(request, entity);

                var result = await _unitOfWork!.TenantRepository.Update(entity);

                _unitOfWork!.CommitAsync().Wait();

                if (result)
                {
                    var response = _mapper!.Map<TenantResponse>(entity);
                    return Ok(ResponseFactory<TenantResponse>.Success(string.Format("Atualiza��o do {0} realizada com sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(string.Format("{0} n�o encontrado para atualiza��o!", _nomeEntidade));
                    return StatusCode(StatusCodes.Status304NotModified, ResponseFactory<TenantResponse>.Error(string.Format("{0} n�o encontrado para atualiza��o!", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Update");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<TenantResponse>.Error(string.Format("Erro ao atualizar a {0} - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(TenantResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(TenantResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(TenantResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(Guid id)
		{
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usu�rio n�o autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<TenantResponse>.Error("Usu�rio n�o autorizado!"));
                }

                if (id.ToString().Length == 0)
                {
                    _logger!.LogWarning("Id informado igual a 0!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<TenantResponse>.Error("Id informado igual a 0!"));
                }

                var entity = _unitOfWork!.TenantRepository.GetById(id).Result;

                if (entity is null)
                {
                    _logger!.LogWarning("Id informado inv�lido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<TenantResponse>.Error("Id informado inv�lido!"));
                }

                var result = await _unitOfWork!.TenantRepository.Delete(id, true);

                _unitOfWork!.CommitAsync().Wait();

                if (result)
                {
                    var response = _mapper!.Map<TenantResponse>(entity);
                    return Ok(ResponseFactory<TenantResponse>.Success(string.Format("Remo��o de {0} realizada com sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(string.Format("{0} n�o encontrada para remo��o!", _nomeEntidade));
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<TenantResponse>.Error(string.Format("{0} n�o encontrada para remo��o!", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Delete");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<TenantResponse>.Error(string.Format("Erro ao remover a {0} - ", _nomeEntidade) + ex.Message));
            }
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
