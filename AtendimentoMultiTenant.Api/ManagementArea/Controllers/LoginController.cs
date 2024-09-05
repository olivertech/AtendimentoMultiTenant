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

                var user = await _unitOfWork!.UserRepository.ValidateLogin(request!.Email!, request!.Password!);

                if (user == null)
                    return BadRequest(new { Message = "Email e/ou senha inválido(s)!" });

                //Gera uma nova secretkey - Será sempre gerado uma nova secretkey a cada novo login
                Tenant? tenant = await _unitOfWork.TenantRepository.GetById(user.TenantId);
                Secret? secret = await _unitOfWork.SecretRepository.GetById(user.TenantId);

                if(secret == null)
                {
                    secret = new Secret
                    {
                        SecretKey = CryptoHelper.GenerateRandomSecret(25),
                        Tenant = tenant,
                        TenantId = tenant!.Id
                    };

                    //Atualiza a secretkey do tenant
                    await _unitOfWork.SecretRepository.Insert(secret!);
                }
                else
                {
                    secret.SecretKey = CryptoHelper.GenerateRandomSecret(25);
                    secret.TenantId = tenant!.Id;

                    //Atualiza a secretkey do tenant
                    await _unitOfWork.SecretRepository.Update(secret!);
                }

                //Gera token
                var newToken = JwtAuth.GenerateToken(user, tenant!.Id, _configuration!);
                var userToken = SetAccessToken(newToken.Token, newToken.ExpirationDate, user);

                user.AccessTokenId = userToken.Result.Id;

                //Atualiza o token do usuário
                await _unitOfWork.UserRepository.Update(user);

                //Insere log de acesso do usuário
                await _unitOfWork.LogAccessRepository.Insert(new LogAccess() 
                { 
                    UserId = user.Id,
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    TimedAt = TimeOnly.Parse(DateTime.Now.ToString("HH:mm:ss")),
                    IsActive = true,
                });

                var response = _mapper!.Map<LoginResponse>(user);

                //response.Secret = secret!;
                response.Id = user.Id;
                response.Role = user!.Role!;
                response.AccessToken = userToken.Result;

                _unitOfWork.CommitAsync().Wait();

                return Ok(ResponseFactory<LoginResponse>.Success("Usuário logado com sucesso.", response));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Auth");
                return BadRequest(new { Message = "Não foi possível autenticar. Ocorreu algum erro interno na aplicação, por favor tente novamente. Caso não consiga, informe o suporte." });
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
                await _unitOfWork.AccessTokenRepository.Delete(user!.AccessTokenId!, false);

                var response = _mapper!.Map<LoginResponse>(user);

                return Ok(ResponseFactory<LoginResponse>.Success("Usuário deslogado com sucesso.", response));
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "Logout");
                return BadRequest(new { Message = "Não foi possível realizar o logout!" });
            }
        }

        private async Task<AccessToken> SetAccessToken(string token, DateOnly expirationDateTime, User user)
        {
            AccessToken? accessToken = null;

            try
            {
                AccessToken newUserToken = new AccessToken
                {
                    Token = token,
                    ExpiringAt = expirationDateTime,
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    TimedAt = TimeOnly.Parse(DateTime.Now.ToString("HH:mm:ss")),
                    IsActive = true
                };

                //Recupera o Token associado ao usuário
                var result = _unitOfWork!.AccessTokenRepository.GetToken(user).Result;

                if (result == null)
                    //Se não existir registro de token associado ao usuário, insere
                    accessToken = await _unitOfWork.AccessTokenRepository.Insert(newUserToken);
                else
                {
                    result.Token = token;
                    result.ExpiringAt = expirationDateTime;
                    result.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
                    result.TimedAt = TimeOnly.Parse(DateTime.Now.ToString("HH:mm:ss"));
                    result.IsActive = true;

                    //Se existir registro de token associado ao usuário, atualiza
                    await _unitOfWork.AccessTokenRepository.Update(result);
                    accessToken = result;
                }
            }
            catch (Exception ex)
            {
                _logger!.LogError(ex, "SetAccessToken");
            }

            return accessToken!;
        }
    }
}
