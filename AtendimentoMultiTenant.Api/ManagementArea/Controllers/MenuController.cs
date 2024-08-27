namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers
{
    [Route("api/Menu")]
    [SwaggerTag("Menu")]
    [ApiController]
    public class MenuController : Base.ControllerBase, IControllerBasic<MenuRequest>
    {
        private readonly ILogger<MenuController>? _logger;
        private readonly IValidator<MenuRequest>? _requestValidator;

        public MenuController(IUnitOfWork unitOfWork,
                                IMapper? mapper,
                                IConfiguration configuration,
                                ILogger<MenuController>? logger,
                                IValidator<MenuRequest>? requestValidator)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Menu";
            _logger = logger;
            _requestValidator = requestValidator;
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

                var list = await _unitOfWork!.MenuRepository.GetAllActivesAndInactives();

                var responseList = _mapper!.Map<IEnumerable<Menu>, IEnumerable<MenuResponse>>(list!);

                return Ok(ResponseFactory<IEnumerable<MenuResponse>>.Success("Lista de " + _nomeEntidade + " recuperada com sucesso.", responseList));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<MenuResponse>.Error("Erro ao recuperar lista " + _nomeEntidade + " - " + ex.Message));
            }
        }

        [HttpGet]
        [Route(nameof(GetAllForLeftMenu))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(MenuResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAllForLeftMenu()
        {
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<MenuResponse>.Error("Usuário não autorizado!"));
                }

                var list = await _unitOfWork!.MenuRepository.GetAllFull();

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

        [HttpGet]
        [Route("GetById/{id:Guid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(MenuResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<MenuResponse>.Error("Usuário não autorizado!"));
                }

                if (!Guid.TryParse(id.ToString(), out _))
                {
                    _logger!.LogWarning("Id inválido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<MenuResponse>.Error("Id inválido!"));
                }

                var entity = await _unitOfWork!.MenuRepository.GetById(id);

                if (entity == null)
                {
                    _logger!.LogWarning("Não existe menu com o Id informado!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<MenuResponse>.Error("Não existe menu com o Id informado!"));
                }

                var response = _mapper!.Map<Menu, MenuResponse>(entity!);

                return Ok(ResponseFactory<MenuResponse>.Success("Consulta realizada com sucesso.", response));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetById");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<MenuResponse>.Error(string.Format("Erro ao recuperar configuração - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpPost]
        [Route(nameof(Insert))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(MenuResponse))]
        public async Task<IActionResult> Insert([FromBody] MenuRequest request)
        {
            try
            { 
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<MenuResponse>.Error("Usuário não autorizado!"));
                }

                if (request is null)
                {
                    _logger!.LogWarning("Request inválido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<MenuResponse>.Error("Request inválido!"));
                }

                var validation = await _requestValidator!.ValidateAsync(request);

                if (!validation.IsValid)
                {
                    _logger!.LogWarning("Request inválido! - " + validation.Errors);
                    return BadRequest(new { Message = validation.Errors });
                }

                var search = _unitOfWork!.MenuRepository.GetAll().Result;

                if (search!.Any(x => x.Name == request.Name) ||
                    search!.Any(x => x.Route == request.Route) ||
                    search!.Any(x => x.Icone == request.Icone))
                {
                    _logger!.LogWarning(string.Format("Já existe um {0} com o mesmo nome, rota ou icone. Verifique os dados enviados e tente novamente.", _nomeEntidade));
                    return Ok(ResponseFactory<MenuResponse>.Error(string.Format("Já existe um {0} com o mesmo nome, rota ou icone. Verifique os dados enviados e tente novamente.", _nomeEntidade)));
                }

                var entity = _mapper!.Map<Menu>(request);

                //Insere novo menu
                var result = await _unitOfWork.MenuRepository.Insert(entity);

                _unitOfWork.CommitAsync().Wait();

                if (result != null)
                {
                    var response = _mapper.Map<MenuResponse>(entity);
                    return Ok(ResponseFactory<MenuResponse>.Success(string.Format("Inclusão de {0} Realizado Com Sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(string.Format("Não foi possível incluir o {0}! Verifique os dados enviados.", _nomeEntidade));
                    return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<MenuResponse>.Error(string.Format("Não foi possível incluir o {0}! Verifique os dados enviados.", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Insert");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<MenuResponse>.Error(string.Format("Erro ao inserir o {0} - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpPut]
        [Route(nameof(Update))]
        //[Consumes("application/json")]
        //[Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status304NotModified, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(MenuResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update([FromBody] MenuRequest request)
        {
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<MenuResponse>.Error("Usuário não autorizado!"));
                }

                if (request is null || !Guid.TryParse(request.Id.ToString(), out _))
                {
                    _logger!.LogWarning("Id informado inválido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<MenuResponse>.Error("Id informado inválido!"));
                }

                var validation = await _requestValidator!.ValidateAsync(request);

                if (!validation.IsValid)
                {
                    _logger!.LogWarning("Request inválido! - " + validation.Errors);
                    return BadRequest(new { Message = validation.Errors });
                }

                var entity = _unitOfWork!.MenuRepository.GetById(request.Id).Result;

                if (entity is null)
                {
                    _logger!.LogWarning("Id informado inválido!");
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<MenuResponse>.Error("Id informado inválido!"));
                }

                var search = _unitOfWork!.MenuRepository.GetAll().Result!.Where(x => !x.Id.Equals(request.Id) 
                                                                                && (x.Name == request.Name
                                                                                || x.Route == request.Route
                                                                                || x.Icone == request.Icone)).ToList();
                if (search.Count() > 0)
                {
                    _logger!.LogWarning(string.Format("Já existe um {0} com o mesmo nome, rota ou icone. Verifique os dados enviados e tente novamente.", _nomeEntidade));
                    return Ok(ResponseFactory<MenuResponse>.Error(string.Format("Já existe um {0} com o mesmo nome, rota ou icone. Verifique os dados enviados e tente novamente.", _nomeEntidade)));
                }

                _mapper!.Map(request, entity);

                var result = await _unitOfWork.MenuRepository.Update(entity);

                _unitOfWork.CommitAsync().Wait();

                if (result)
                {
                    var response = _mapper!.Map<MenuResponse>(entity);
                    return Ok(ResponseFactory<MenuResponse>.Success(string.Format("Atualização do {0} realizada com sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(string.Format("{0} não encontrado para atualização!", _nomeEntidade));
                    return StatusCode(StatusCodes.Status304NotModified, ResponseFactory<MenuResponse>.Error(string.Format("{0} não encontrado para atualização!", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Update");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<MenuResponse>.Error(string.Format("Erro ao atualizar a {0} - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(MenuResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(MenuResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<MenuResponse>.Error("Usuário não autorizado!"));
                }

                if (id.ToString().Length == 0)
                {
                    _logger!.LogWarning("Id informado igual a 0!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<MenuResponse>.Error("Id informado igual a 0!"));
                }

                var entity = _unitOfWork!.MenuRepository.GetById(id).Result;

                if (entity is null)
                {
                    _logger!.LogWarning("Id informado inválido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<MenuResponse>.Error("Id informado inválido!"));
                }

                var result = await _unitOfWork.MenuRepository.Delete(id, true);

                _unitOfWork.CommitAsync().Wait();

                if (result)
                {
                    var response = _mapper!.Map<MenuResponse>(entity);
                    return Ok(ResponseFactory<MenuResponse>.Success(string.Format("Remoção de {0} realizada com sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(string.Format("{0} não encontrada para remoção!", _nomeEntidade));
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<MenuResponse>.Error(string.Format("{0} não encontrada para remoção!", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Delete");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<MenuResponse>.Error(string.Format("Erro ao remover a {0} - ", _nomeEntidade) + ex.Message));
            }
        }
    }
}
