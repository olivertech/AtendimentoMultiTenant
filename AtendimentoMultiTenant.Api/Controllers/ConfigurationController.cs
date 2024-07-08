using AtendimentoMultiTenant.Cross.Interfaces;
using System.Collections.Generic;

namespace AtendimentoMultiTenant.Api.Controllers
{
    [Route("api/Configuration")]
    [SwaggerTag("Configuration")]
    [ApiController]
    public class ConfigurationController : Base.ControllerBase
    {
        private readonly IPortHelper _portHelper;
        public ConfigurationController(IUnitOfWork unitOfWork, 
                                       IMapper? mapper, 
                                       IConfiguration configuration,
                                       IPortHelper portHelper)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Container";
            _portHelper = portHelper;
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError, Type = typeof(ContainerDbResponse))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _unitOfWork!.ContainerRepository.GetAll();
                var responseList = _mapper!.Map<IEnumerable<ContainerDb>, IEnumerable<ContainerDbResponse>>(list!);

                return Ok(ResponseFactory<IEnumerable<ContainerDbResponse>>.Success(true, "Lista recuperada com sucesso.", responseList));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Erro ao listar configurações - ") + ex.Message));
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
            if (!Guid.TryParse(id.ToString(), out _))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Id inválido!"));

            var entity = await _unitOfWork!.ContainerRepository.GetById(id);

            if (entity == null)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Id inválido!"));

            var response = _mapper!.Map<ContainerDb, ContainerDbResponse>(entity!);

            return Ok(ResponseFactory<ContainerDbResponse>.Success(true, "Consulta realizada com sucesso.", response));
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
            if (name is null)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Nome inválido!"));

            var entities = await _unitOfWork!.ContainerRepository.GetList(x => x.ContainerDbName!.ToLower() == name.ToLower());

            if (entities == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error(false, "Não existem configurações para esse nome!"));

            var response = _mapper!.Map<IEnumerable<ContainerDb>, IEnumerable<ContainerDbResponse>>(entities!);

            return Ok(ResponseFactory<IEnumerable<ContainerDbResponse>>.Success(true, "Consulta realizada com sucesso.", response));
        }

        [HttpGet]
        [Route(nameof(GetCount))]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _unitOfWork!.ContainerRepository.Count();
            return Ok(ResponseFactory<int>.Success(true, "Consulta realizada com sucesso.", result)); ;
        }

        [HttpPost]
        [Route(nameof(Insert))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerDbResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerDbResponse))]
        public ActionResult<ContainerDbResponse> Insert([FromBody] ConfigurationRequest request)
        {
            try
            {
                if (request is null)
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Request inválido!"));

                var search = _unitOfWork!.ContainerRepository.GetAll().Result;

                if (search!.Any(x => x.ContainerDbName == request.ContainerName) ||
                    search!.Any(x => x.ContainerDbVolume == request.ContainerVolume) ||
                    search!.Any(x => x.ContainerDbNetwork == request.ContainerNetwork))
                    return Ok(ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade)));

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

                var result = _unitOfWork.ContainerRepository.Insert(entity);

                _unitOfWork.CommitAsync().Wait();

                if (result != null)
                {
                    var response = _mapper.Map<ContainerDbResponse>(entity);
                    return Ok(ResponseFactory<ContainerDbResponse>.Success(true, String.Format("Inclusão de {0} Realizado Com Sucesso.", _nomeEntidade), response));
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Não foi possível incluir o {0}! Verifique os dados enviados.", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Erro ao inserir o {0} -> ", _nomeEntidade) + ex.Message));
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
        public ActionResult<ContainerDbResponse> Update(ContainerDbRequest request)
        {
            try
            {
                if (request is null || !Guid.TryParse(request.Id.ToString(), out _))
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Id informado inválido!"));

                var entity = _unitOfWork!.ContainerRepository.GetById(request.Id).Result;

                if (entity is null)
                    return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error(false, "Id informado inválido!"));

                var search = _unitOfWork!.ContainerRepository.GetAll().Result;

                if (search!.Any(x => x.ContainerDbName == request.ContainerDbName) ||
                    search!.Any(x => x.ContainerDbVolume == request.ContainerVolume) ||
                    search!.Any(x => x.ContainerDbNetwork == request.ContainerNetwork))
                    return Ok(ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade)));

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
                    return StatusCode(StatusCodes.Status304NotModified, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("{0} não encontrado para atualização!", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("Erro ao atualizar a {0} -> ", _nomeEntidade) + ex.Message));
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
            if (id.ToString().Length == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Id informado igual a 0!"));

            var entity = _unitOfWork!.ContainerRepository.GetById(id).Result;

            if (entity is null)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseFactory<ContainerDbResponse>.Error(false, "Id informado inválido!"));

            var result = _unitOfWork.ContainerRepository.Delete(id).Result;

            _unitOfWork.CommitAsync().Wait();

            if (result)
            {
                var response = _mapper!.Map<ContainerDbResponse>(entity);
                return Ok(ResponseFactory<ContainerDbResponse>.Success(true, String.Format("Remoção de {0} realizada com sucesso.", _nomeEntidade), response));
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerDbResponse>.Error(false, String.Format("{0} não encontrada para remoção!", _nomeEntidade)));
            }
        }
    }
}
