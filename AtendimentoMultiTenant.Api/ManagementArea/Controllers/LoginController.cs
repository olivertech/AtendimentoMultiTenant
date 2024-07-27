﻿using AtendimentoMultiTenant.Api.ManagementArea.Auth;
using AtendimentoMultiTenant.Api.ManagementArea.Helpers;

namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers
{
    [Route("api/Login")]
    [SwaggerTag("Login")]
    [ApiController]
    public class LoginController : Base.ControllerBase
    {
        private const string _msgPrefixError = "Request inválido! - ";
        private readonly ILogger<LoginController>? _logger;
        private readonly IValidator<LoginRequest> _validator;

        public LoginController(IUnitOfWork unitOfWork,
                               IMapper? mapper,
                               IConfiguration configuration,
                               ILogger<LoginController>? logger,
                               IValidator<LoginRequest> validator)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Login";
            _logger = logger;
            _validator = validator;
        }

        [HttpPost]
        [Route(nameof(Auth))]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Auth([FromBody] LoginRequest request)
        {
            try
            {
                var validation = await _validator.ValidateAsync(request);

                if (!validation.IsValid)
                {
                    _logger!.LogWarning(_msgPrefixError + validation.Errors);
                    return BadRequest(new { Message = validation.Errors });
                }

                if (request is null)
                    return BadRequest(new { Message = "Request inválido!" });

                var user = _unitOfWork!.UserRepository.ValidateLogin(request!.Email!, request!.Password!).Result;

                if (user == null)
                    return BadRequest(new { Message = "Email e/ou senha inválido(s)!" });

                //Gera o identificador que vai servir como mais um item de validação do token
                var identifier = IdentifierHelper.SetIdentifier(user.Id, user.UserTokenId);
                var newToken = JwtAuth.GenerateToken(user, identifier, _configuration!);

                var userToken = SetUserToken(newToken.Token, newToken.ExpirationDate, user);

                user.UserTokenId = userToken.Result.Id;

                //Atualiza o token do usuário
                await _unitOfWork.UserRepository.Update(user);

                var response = _mapper!.Map<LoginResponse>(user);

                _unitOfWork.CommitAsync().Wait();

                response.Token = newToken.Token;
                response.Identifier = identifier;

                return Ok(ResponseFactory<LoginResponse>.Success(true, "Usuário logado com sucesso.", response));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Auth");
                return BadRequest(new { Message = "Não foi possível autenticar. Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }

        [HttpPost]
        [Route(nameof(Logout))]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            if (request is null)
                return BadRequest(new { Message = "Request inválido!" });

            try
            {
                var user = await _unitOfWork!.UserRepository.GetById(request.UserId);
                await _unitOfWork.UserTokenRepository.Delete(user!.UserTokenId!);

                var response = _mapper!.Map<LoginResponse>(user);

                return Ok(ResponseFactory<LoginResponse>.Success(true, "Usuário deslogado com sucesso.", response));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Logout");
                return BadRequest(new { Message = "Não foi possível realizar o logout!" });
            }
        }

        private async Task<UserToken> SetUserToken(string token, DateOnly expirationDateTime, User user)
        {
            UserToken? userToken = null;

            try
            {
                UserToken newUserToken = new UserToken
                {
                    Token = token,
                    ExpiringAt = expirationDateTime,
                };

                //Recupera o Token associado ao usuário
                var result = _unitOfWork!.UserTokenRepository.GetToken(user).Result;

                //TODO: DEPOIS QUE TIVER O FRONT, ENVIAR NO REQUEST DO FRONT, UM GUID
                //QUE DEVERÁ SER VALIDADO NO BACK
                if (result == null)
                    //Se não existir registro de token associado ao usuário, insere
                    userToken = await _unitOfWork.UserTokenRepository.Insert(newUserToken);
                else
                {
                    //Se existir registro de token associado ao usuário, atualiza
                    await _unitOfWork.UserTokenRepository.Update(newUserToken);
                    userToken = result;
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "SetUserToken");
            }

            return userToken!;
        }
    }
}
