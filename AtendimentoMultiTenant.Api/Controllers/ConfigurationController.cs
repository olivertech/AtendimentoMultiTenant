using AtendimentoMultiTenant.Cross.Helpers;
using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace AtendimentoMultiTenant.Api.Controllers
{
    [Route("api/Plan")]
    [SwaggerTag("Configuration")]
    [ApiController]
    public class ConfigurationController : Base.ControllerBase
    {
        public ConfigurationController(IUnitOfWork unitOfWork, 
                                       IMapper? mapper, 
                                       IConfiguration configuration)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Container";
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _unitOfWork!.ContainerRepository.GetAll();
            return Ok(list);
        }

        [HttpGet]
        [Route("Get/{id:Guid}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out _))
                return BadRequest(ResponseFactory<ContainerResponse>.Error(false, "Id inválido!"));

            var entities = await _unitOfWork!.ContainerRepository.GetById(id);
            return Ok(entities);
        }

        [HttpGet]
        [Route(nameof(GetListByName))]
        [Produces("application/json")]
        public async Task<IActionResult> GetListByName(string name)
        {
            if (name is null)
                return BadRequest(ResponseFactory<ContainerResponse>.Error(false, "Nome inválido!"));

            var entities = await _unitOfWork!.ContainerRepository.GetList(x => x.ContainerName!.ToLower() == name.ToLower());
            return Ok(entities);
        }

        [HttpGet]
        [Route(nameof(GetCount))]
        [Produces("application/json")]
        public async Task<IActionResult> GetCount()
        {
            var entities = await _unitOfWork!.ContainerRepository.Count();
            return Ok(entities);
        }

        [HttpPost]
        [Route(nameof(Insert))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerResponse))]
        public ActionResult<ContainerResponse> Insert([FromBody] ContainerRequest request)
        {
            try
            {
                if (request is null)
                    return BadRequest(ResponseFactory<ContainerResponse>.Error(false, "Request inválido!"));

                var search = _unitOfWork!.ContainerRepository.GetAll().Result;

                if (search!.Any(x => x.ContainerName == request.ContainerName) ||
                    search!.Any(x => x.ContainerVolume == request.ContainerVolume) ||
                    search!.Any(x => x.ContainerNetwork == request.ContainerNetwork))
                    return Ok(ResponseFactory<ContainerResponse>.Error(false, String.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade)));

                var entity = _mapper!.Map<Core.Entities.ConfigurationEntities.Container>(request);

                entity.Id = Guid.NewGuid();
                entity.ContainerImage = _configuration!.GetSection("ContainerDatabaseImage").Value!;
                entity.ContainerCreatedAt = DateOnly.FromDateTime(DateTime.Now);
                entity.ContainerPort = PortHelper.GetPortNumber();
                entity.IsUp = false;

                var result = _unitOfWork.ContainerRepository.Insert(entity);

                _unitOfWork.CommitAsync().Wait();

                if (result != null)
                {
                    var response = _mapper.Map<ContainerResponse>(entity);
                    return Ok(ResponseFactory<ContainerResponse>.Success(true, String.Format("Inclusão de {0} Realizado Com Sucesso.", _nomeEntidade), response));
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerResponse>.Error(false, String.Format("Não foi possível incluir o {0}! Verifique os dados enviados.", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerResponse>.Error(false, String.Format("Erro ao inserir o {0} -> ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpPut]
        [Route(nameof(Update))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status304NotModified, Type = typeof(ContainerResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(ContainerResponse))]
        public ActionResult<ContainerResponse> Update(ContainerRequest request)
        {
            try
            {
                if (request is null || !Guid.TryParse(request.Id.ToString(), out _))
                    return BadRequest(ResponseFactory<ContainerResponse>.Error(false, "Id informado inválido!"));

                var entity = _unitOfWork!.ContainerRepository.GetById(request.Id).Result;

                if (entity is null)
                    return NotFound(ResponseFactory<ContainerResponse>.Error(false, "Id informado inválido!"));

                var search = _unitOfWork!.ContainerRepository.GetAll().Result;

                if (search!.Any(x => x.ContainerName == request.ContainerName) ||
                    search!.Any(x => x.ContainerVolume == request.ContainerVolume) ||
                    search!.Any(x => x.ContainerNetwork == request.ContainerNetwork))
                    return Ok(ResponseFactory<ContainerResponse>.Error(false, String.Format("Já existe um {0} com o mesmo nome, porta, volume ou rede. Verifique os dados enviados e tente novamente.", _nomeEntidade)));

                _mapper!.Map(request, entity);

                var result = _unitOfWork.ContainerRepository.Update(entity).Result;

                _unitOfWork.CommitAsync().Wait();

                if (result)
                {
                    var response = _mapper!.Map<ContainerResponse>(entity);
                    return Ok(ResponseFactory<ContainerResponse>.Success(true, String.Format("Atualização do {0} realizada com sucesso.", _nomeEntidade), response));
                }
                else
                {
                    return StatusCode(StatusCodes.Status304NotModified, ResponseFactory<ContainerResponse>.Error(false, String.Format("{0} não encontrado para atualização!", _nomeEntidade)));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseFactory<ContainerResponse>.Error(false, String.Format("Erro ao atualizar a {0} -> ", _nomeEntidade) + ex.Message));
            }
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, Type = typeof(ContainerResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound, Type = typeof(ContainerResponse))]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest, Type = typeof(ContainerResponse))]
        public IActionResult Delete(Guid id)
        {
            if (id.ToString().Length == 0)
                return BadRequest(ResponseFactory<ContainerResponse>.Error(false, "Id informado igual a 0!"));

            var entity = _unitOfWork!.ContainerRepository.GetById(id).Result;

            if (entity is null)
                return NotFound(ResponseFactory<ContainerResponse>.Error(false, "Id informado inválido!"));

            var result = _unitOfWork.ContainerRepository.Delete(id).Result;

            _unitOfWork.CommitAsync().Wait();

            if (result)
            {
                var response = _mapper!.Map<ContainerResponse>(entity);
                return Ok(ResponseFactory<ContainerResponse>.Success(true, String.Format("Remoção de {0} realizada com sucesso.", _nomeEntidade), response));
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseFactory<ContainerResponse>.Error(false, String.Format("{0} não encontrada para remoção!", _nomeEntidade)));
            }
        }
    }
}
