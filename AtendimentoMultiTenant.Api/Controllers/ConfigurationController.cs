namespace AtendimentoMultiTenant.Api.Controllers
{
    [Route("api/Configuration")]
    [SwaggerTag("Configuration")]
    [ApiController]
    public class ConfigurationController : Base.ControllerBase
    {
        private readonly IPortHelper _portHelper;
        private readonly ILogger<ConfigurationController>? _logger;
        private readonly IValidator<ConfigurationRequest>? _configurationRequestValidator;
        private readonly IValidator<ContainerDbRequest>? _containerDbRequestValidator;

        public ConfigurationController(IUnitOfWork unitOfWork,
                                       IMapper? mapper,
                                       IConfiguration configuration,
                                       IPortHelper portHelper,
                                       ILogger<ConfigurationController>? logger,
                                       IValidator<ConfigurationRequest> configurationRequestValidator,
                                       IValidator<ContainerDbRequest> containerDbRequestValidator)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Container";
            _portHelper = portHelper;
            _logger = logger;
            _configurationRequestValidator = configurationRequestValidator;
            _containerDbRequestValidator = containerDbRequestValidator;
        }

        [HttpPost]
        [Route(nameof(GetAll))]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(ContainerDbResponse))]
        public async Task<IActionResult> GetAll([FromBody] ContainerDbPagedRequest request)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;

                //TODO:QDO TIVER O FRONT PRONTO, INCLUIR NESSE MÉTODO O REQUEST COM VALOR RECUPERADO DE COOKIE
                //PARA CHECAR SE O COOKIE RECEBIDO AQUI, É IGUAL A UM DETERMINADO DADO DO BANCO. TALVEZ USAR
                //UMA GUID GERADA POR SESSÃO
                if (!IsUserClaimsValid(identity!))
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<ContainerDbResponse>.Error(false, "Usuário não autorizado!"));
                }

                var list = await _unitOfWork!.ContainerRepository.GetPagedList(request.PageSize, request.PageNumber);
                var total = await _unitOfWork!.ContainerRepository.Count();

                var responseList = _mapper!.Map<IEnumerable<ContainerDb>, IEnumerable<ContainerDbResponse>>(list!);

                return Ok(ResponsePagedFactory<IEnumerable<ContainerDbResponse>>.Success(true, "Lista recuperada com sucesso.", responseList, request.PageNumber, total));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Erro ao listar configurações - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpGet]
        [Route("Get/{id:Guid}")]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (!Guid.TryParse(id.ToString(), out _))
                {
                    _logger!.LogWarning("Id inválido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Id inválido!"));
                }

                var entity = await _unitOfWork!.ContainerRepository.GetById(id);

                if (entity == null)
                {
                    _logger!.LogWarning("Não existe configuração com o Id informado!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Não existe configuração com o Id informado!"));
                }

                var response = _mapper!.Map<ContainerDb, ContainerDbResponse>(entity!);

                return Ok(ResponseFactory<ContainerDbResponse>.Success(true, "Consulta realizada com sucesso.", response));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetById");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Erro ao recuperar configuração - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpGet]
        [Route(nameof(GetListByName))]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(ContainerDbResponse))]
        public async Task<IActionResult> GetListByName(string name)
        {
            try
            {
                if (name is null)
                {
                    _logger!.LogWarning("Nome inválido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Nome inválido!"));
                }

                var entities = await _unitOfWork!.ContainerRepository.GetList(x => x.ContainerDbName!.ToLower() == name.ToLower());

                if (entities == null)
                {
                    _logger!.LogWarning("Não existem configurações para esse nome!");
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error(false, "Não existem configurações para esse nome!"));
                }

                var response = _mapper!.Map<IEnumerable<ContainerDb>, IEnumerable<ContainerDbResponse>>(entities!);

                return Ok(ResponseFactory<IEnumerable<ContainerDbResponse>>.Success(true, "Consulta realizada com sucesso.", response));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetListByName");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Erro ao recuperar lista de configurações por nome - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpGet]
        [Route(nameof(GetCount))]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetCount()
        {
            try
            {
                var result = await _unitOfWork!.ContainerRepository.Count();
                return Ok(ResponseFactory<int>.Success(true, "Consulta realizada com sucesso.", result)); ;

            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetCount");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Erro ao recuperar total de configurações - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpPost]
        [Route(nameof(Insert))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
        public async Task<ActionResult<ContainerDbResponse>> Insert([FromBody] ConfigurationRequest request)
        {
            try
            {
                if (request is null)
                {
                    _logger!.LogWarning("Request inválido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Request inválido!"));
                }

                var validation = await _configurationRequestValidator!.ValidateAsync(request);

                if (!validation.IsValid)
                {
                    _logger!.LogWarning("Request inválido! - " + validation.Errors);
                    return BadRequest(new { Message = validation.Errors });
                }

                var search = _unitOfWork!.ContainerRepository.GetAllFull().Result;

                if (search!.Any(x => x!.Tenant!.Name == request.ClientName) ||
                    search!.Any(x => x!.ContainerDbName == request.ContainerDbName) ||
                    search!.Any(x => x!.ContainerDbVolume == request.ContainerDbVolume) ||
                    search!.Any(x => x!.ContainerDbNetwork == request.ContainerDbNetwork))
                {
                    _logger!.LogWarning(String.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade));
                    return Ok(ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade)));
                }

                var entity = _mapper!.Map<ContainerDb>(request);

                entity.ContainerDbImage = _configuration!.GetSection("ContainerDatabaseImage").Value!;
                entity.ContainerDbCreatedAt = DateOnly.FromDateTime(DateTime.Now);
                entity.ContainerDbPort = _portHelper.GetNewPortNumber();
                entity.IsUp = false;

                //Insere o novo Port e associa o id
                entity.PortId = _unitOfWork.PortRepository.Insert(new Port
                {
                    PortNumber = entity.ContainerDbPort
                }).Result!.Id;

                //Insere o novo Tenant e associa o id
                entity.TenantId = _unitOfWork.TenantRepository.Insert(new Tenant
                {
                    InitialUrl = $"https://localhost:{entity.ContainerDbPort}",
                    Secret = "123",
                    ConnectionString = $"Host=localhost;Port={entity.PortId};Database={request.EnvironmentDbName};User ID={request.EnvironmentDbUser};Password={request.EnvironmentDbPwd};Pooling=true;",
                    IsActive = true,
                    Name = request.ClientName
                }).Result!.Id;

                //Insere novo Usuário do Tenant e associa o id
                User newUser = _unitOfWork.UserRepository.Insert(new User
                {
                    Name = "Administrador",
                    Email = "admin@" + request.ClientName + ".com.br",
                    Password = "123",
                    IsActive = true,
                    TenantId = entity.TenantId,
                    UserTypeId = _unitOfWork.UserTypeRepository.GetList(x => x.Name!.ToLower().Equals("administrador")).Result!.FirstOrDefault()!.Id

                }).Result!;

                //Insere novo Container, já tendo as referencias definidas acima
                var result = _unitOfWork.ContainerRepository.Insert(entity);

                _unitOfWork.CommitAsync().Wait();

                if (result != null)
                {
                    var response = _mapper.Map<ContainerDbResponse>(entity);
                    return Ok(ResponseFactory<ContainerDbResponse>.Success(true, String.Format("Inclusão de {0} Realizado Com Sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(String.Format("Não foi possível incluir o {0}! Verifique os dados enviados.", _nomeEntidade));
                    return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Não foi possível incluir o {0}! Verifique os dados enviados.", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Insert");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Erro ao inserir o {0} - ", _nomeEntidade) + ex.Message));
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
        public async Task<ActionResult<ContainerDbResponse>> Update(ContainerDbRequest request)
        {
            try
            {
                if (request is null || !Guid.TryParse(request.Id.ToString(), out _))
                {
                    _logger!.LogWarning("Id informado inválido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Id informado inválido!"));
                }

                var validation = await _containerDbRequestValidator!.ValidateAsync(request);

                if (!validation.IsValid)
                {
                    _logger!.LogWarning("Request inválido! - " + validation.Errors);
                    return BadRequest(new { Message = validation.Errors });
                }

                var entity = _unitOfWork!.ContainerRepository.GetById(request.Id).Result;

                if (entity is null)
                {
                    _logger!.LogWarning("Id informado inválido!");
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error(false, "Id informado inválido!"));
                }

                var search = _unitOfWork!.ContainerRepository.GetAll().Result;

                if (search!.Any(x => x.ContainerDbName == request.ContainerDbName) ||
                    search!.Any(x => x.ContainerDbVolume == request.ContainerVolume) ||
                    search!.Any(x => x.ContainerDbNetwork == request.ContainerNetwork))
                {
                    _logger!.LogWarning(String.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade));
                    return Ok(ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade)));

                }

                _mapper!.Map(request, entity);

                var result = _unitOfWork.ContainerRepository.Update(entity).Result;

                _unitOfWork.CommitAsync().Wait();

                if (result)
                {
                    var response = _mapper!.Map<ContainerDbResponse>(entity);
                    return Ok(ResponseFactory<ContainerDbResponse>.Success(true, String.Format("Atualização do {0} realizada com sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(String.Format("{0} não encontrado para atualização!", _nomeEntidade));
                    return StatusCode(StatusCodes.Status304NotModified, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("{0} não encontrado para atualização!", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Update");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Erro ao atualizar a {0} - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (id.ToString().Length == 0)
                {
                    _logger!.LogWarning("Id informado igual a 0!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Id informado igual a 0!"));
                }
                var entity = _unitOfWork!.ContainerRepository.GetById(id).Result;

                if (entity is null)
                {
                    _logger!.LogWarning("Id informado inválido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Id informado inválido!"));
                }

                var result = _unitOfWork.ContainerRepository.Delete(id).Result;

                _unitOfWork.CommitAsync().Wait();

                if (result)
                {
                    var response = _mapper!.Map<ContainerDbResponse>(entity);
                    return Ok(ResponseFactory<ContainerDbResponse>.Success(true, String.Format("Remoção de {0} realizada com sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(String.Format("{0} não encontrada para remoção!", _nomeEntidade));
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("{0} não encontrada para remoção!", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Delete");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Erro ao remover a {0} - ", _nomeEntidade) + ex.Message));
            }
        }
    }
}
