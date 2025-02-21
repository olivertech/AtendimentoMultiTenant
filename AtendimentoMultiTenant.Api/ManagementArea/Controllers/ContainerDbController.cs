﻿namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers
{
    [Route("api/ContainerDb")]
    [SwaggerTag("ContainerDb")]
    [ApiController]
    public class ContainerDbController : Base.ControllerBase, IControllerFull<ContainerDbRequest, ContainerDbPagedRequest>
    {
        private readonly IPortFinder _portFinder;
        private readonly ILogger<ContainerDbController>? _logger;
        private readonly IValidator<ContainerDbRequest>? _requestValidator;

        public ContainerDbController(IUnitOfWork unitOfWork,
                                       IMapper? mapper,
                                       IConfiguration configuration,
                                       IPortFinder portFinder,
                                       ILogger<ContainerDbController>? logger,
                                       IValidator<ContainerDbRequest> requestValidator)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Containers";
            _portFinder = portFinder;
            _logger = logger;
            _requestValidator = requestValidator;
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
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<LogAccessResponse>.Error("Usuário não autorizado!"));
                }

                var list = await _unitOfWork!.ContainerDbRepository.GetAllFull();

                var responseList = _mapper!.Map<IEnumerable<ContainerDb>, IEnumerable<ContainerDbResponse>>(list!);

                return Ok(ResponseFactory<IEnumerable<ContainerDbResponse>>.Success($"Lista de {_nomeEntidade} recuperada com sucesso.", responseList));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error($"Erro ao recuperar lista {_nomeEntidade} - " + ex.Message));
            }
        }

        [HttpPost]
        [Route(nameof(GetAll))]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(LogAccessResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(LogAccessResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized, Type = typeof(LogAccessResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll([FromBody] ContainerDbPagedRequest request)
        {
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<ContainerDbResponse>.Error("Usuário não autorizado!"));
                }

                var list = await _unitOfWork!.LogAccessRepository.GetPagedList(request.PageSize, request.PageNumber);

                var responseList = _mapper!.Map<IEnumerable<LogAccess>, IEnumerable<ContainerDbResponse>>(list!);

                return Ok(ResponsePagedFactory<IEnumerable<ContainerDbResponse>>.Success($"Lista de {_nomeEntidade} recuperada com sucesso.", responseList, request.PageNumber, request.PageSize));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error($"Erro ao recuperar lista de {_nomeEntidade} - " + ex.Message));
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
                    _logger!.LogWarning("Não existe configuração com o Id informado!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error("Não existe configuração com o Id informado!"));
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

        [HttpGet]
        [Route(nameof(GetListByName))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(ContainerDbResponse))]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetListByName(string name)
        {
            try
            {
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<ContainerDbResponse>.Error("Usuário não autorizado!"));
                }

                if (name is null)
                {
                    _logger!.LogWarning("Nome inválido!");
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error("Nome inválido!"));
                }

                var entities = await _unitOfWork!.ContainerDbRepository.GetList(x => x.ContainerDbName!.ToLower() == name.ToLower());

                if (entities == null)
                {
                    _logger!.LogWarning("Não existem configurações para esse nome!");
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error("Não existem configurações para esse nome!"));
                }

                var response = _mapper!.Map<IEnumerable<ContainerDb>, IEnumerable<ContainerDbResponse>>(entities!);

                return Ok(ResponseFactory<IEnumerable<ContainerDbResponse>>.Success("Consulta realizada com sucesso.", response));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetListByName");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Erro ao recuperar lista de configurações por nome - ", _nomeEntidade) + ex.Message));
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
                if (!IsUserClaimsValid())
                {
                    _logger!.LogWarning("Usuário não autorizado!");
                    return StatusCode(StatusCodes.Status401Unauthorized, ResponseFactory<ContainerDbResponse>.Error("Usuário não autorizado!"));
                }

                var result = await _unitOfWork!.ContainerDbRepository.Count();
                return Ok(ResponseFactory<int>.Success("Consulta realizada com sucesso.", result)); ;

            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "GetCount");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Erro ao recuperar total de configurações - ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpPost]
        [Route(nameof(Insert))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
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

                var validation = await _requestValidator!.ValidateAsync(request);

                if (!validation.IsValid)
                {
                    _logger!.LogWarning("Request inválido! - " + validation.Errors);
                    return BadRequest(new { Message = validation.Errors });
                }

                var search = _unitOfWork!.ContainerDbRepository.GetAll(true).Result!.Where(x => !x.Id.Equals(request.Id)
                                                                && (x.ContainerDbName == request.ContainerDbName
                                                                || x.ContainerDbVolume == request.ContainerDbVolume
                                                                || x.ContainerDbNetwork == request.ContainerDbNetwork)).ToList();

                if (search.Count() > 0)
                {
                    _logger!.LogWarning(string.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade));
                    return Ok(ResponseFactory<ContainerDbResponse>.Error(string.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade)));
                }

                var entity = _mapper!.Map<ContainerDb>(request);

                entity.ContainerDbImage = _configuration!.GetSection("ContainerDatabaseImage").Value!;
                entity.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
                entity.ContainerDbPort = _portFinder.GetNewPortNumber();
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
                    ConnectionString = $"Host=localhost;Port={entity.PortId};Database={request.EnvironmentDbName};User ID={request.EnvironmentDbUser};Password={request.EnvironmentDbPwd};Pooling=true;",
                    IsActive = true,
                    Name = request.ContainerDbName!.ToLower()
                }).Result!.Id;

                //Insere novo Usuário do Tenant e associa o id
                User newUser = _unitOfWork.UserRepository.Insert(new User
                {
                    Name = "Administrador",
                    Email = "admin@" + request.ContainerDbName!.ToLower() + ".com.br",
                    Password = "123",
                    IsActive = true,
                    TenantId = entity.TenantId,
                    //UserTypeId = _unitOfWork.UserTypeRepository.GetList(x => x.Name!.ToLower().Equals("administrador")).Result!.FirstOrDefault()!.Id

                }).Result!;

                //Insere novo Container, já tendo as referencias definidas acima
                var result = _unitOfWork.ContainerDbRepository.Insert(entity);

                _unitOfWork.CommitAsync().Wait();

                if (result != null)
                {
                    var response = _mapper.Map<ContainerDbResponse>(entity);
                    return Ok(ResponseFactory<ContainerDbResponse>.Success(string.Format("Inclusão de {0} Realizado Com Sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(string.Format("Não foi possível incluir o {0}! Verifique os dados enviados.", _nomeEntidade));
                    return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Não foi possível incluir o {0}! Verifique os dados enviados.", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Insert");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Erro ao inserir o {0} - ", _nomeEntidade) + ex.Message));
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

                var validation = await _requestValidator!.ValidateAsync(request);

                if (!validation.IsValid)
                {
                    _logger!.LogWarning("Request inválido! - " + validation.Errors);
                    return BadRequest(new { Message = validation.Errors });
                }

                var entity = _unitOfWork!.ContainerDbRepository.GetById(request.Id).Result;

                if (entity is null)
                {
                    _logger!.LogWarning("Id informado inválido!");
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error("Id informado inválido!"));
                }

                var search = _unitOfWork!.ContainerDbRepository.GetAll(true).Result!.Where(x => !x.Id.Equals(request.Id)
                                                                && (x.ContainerDbName == request.ContainerDbName
                                                                || x.ContainerDbVolume == request.ContainerDbVolume
                                                                || x.ContainerDbNetwork == request.ContainerDbNetwork)).ToList();

                if (search.Count() > 0)
                {
                    _logger!.LogWarning(string.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade));
                    return Ok(ResponseFactory<ContainerDbResponse>.Error(string.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade)));
                }

                _mapper!.Map(request, entity);

                var result = await _unitOfWork.ContainerDbRepository.Update(entity);

                _unitOfWork.CommitAsync().Wait();

                if (result)
                {
                    var response = _mapper!.Map<ContainerDbResponse>(entity);
                    return Ok(ResponseFactory<ContainerDbResponse>.Success(string.Format("Atualização do {0} realizada com sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(string.Format("{0} não encontrado para atualização!", _nomeEntidade));
                    return StatusCode(StatusCodes.Status304NotModified, ResponseFactory<ContainerDbResponse>.Error(string.Format("{0} não encontrado para atualização!", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Update");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Erro ao atualizar a {0} - ", _nomeEntidade) + ex.Message));
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

                var result = await _unitOfWork.ContainerDbRepository.Delete(id, true);

                _unitOfWork.CommitAsync().Wait();

                if (result)
                {
                    var response = _mapper!.Map<ContainerDbResponse>(entity);
                    return Ok(ResponseFactory<ContainerDbResponse>.Success(string.Format("Remoção de {0} realizada com sucesso.", _nomeEntidade), response));
                }
                else
                {
                    _logger!.LogWarning(string.Format("{0} não encontrada para remoção!", _nomeEntidade));
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error(string.Format("{0} não encontrada para remoção!", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Delete");
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(string.Format("Erro ao remover a {0} - ", _nomeEntidade) + ex.Message));
            }
        }
    }
}
