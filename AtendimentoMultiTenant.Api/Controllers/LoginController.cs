using AtendimentoMultiTenant.Cross.Auth;

namespace AtendimentoMultiTenant.Api.Controllers
{
    [Route("api/Login")]
    [SwaggerTag("Login")]
    [ApiController]
    public class LoginController : Base.ControllerBase
    {
        public LoginController(IUnitOfWork unitOfWork,
                               IMapper? mapper,
                               IConfiguration configuration)
            : base(unitOfWork, mapper, configuration)
        {
            _nomeEntidade = "Login";
        }

        [HttpPost]
        [Route(nameof(Auth))]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Auth([FromBody] LoginRequest request)
        {
            DateTime expirationDateTime = DateTime.MinValue;

            try
            {
                if(request is null)
                    return BadRequest(new { Message = "Request inválido!" });

                var userExists = _unitOfWork!.UserRepository.GetByEmail(request!.Email!).Result;

                if (userExists == null)
                    return BadRequest(new { Message = "Email e/ou senha inválido(s)!" });

                if (request.Password != userExists.Password)
                    return BadRequest(new { Message = "Email e/ou senha inválido(s)!" });

                var token = JwtAuth.GenerateToken(userExists, _configuration!, ref expirationDateTime);

                var userToken = SetUserToken(token, expirationDateTime, userExists);

                userExists.UserTokenId = userToken.Result.Id;
                
                //Atualiza o token do usuário
                await _unitOfWork.UserRepository.Update(userExists);

                var response = _mapper!.Map<UserLoginResponse>(userExists);

                _unitOfWork.CommitAsync().Wait();

                return Ok(new
                {
                    Token = token,
                    Usuario = response
                });
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Não foi possível autenticar. Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }

        private async Task<UserToken> SetUserToken(string token, DateTime expirationDateTime, User user)
        {
            UserToken? userToken = null;
            
            UserToken newUserToken = new UserToken
            {
                Token = token,
                Expiration = expirationDateTime
            };

            //Recupera o Token associado ao usuário
            var result = _unitOfWork!.UserTokenRepository.GetToken(user).Result;

            if (result == null)
                //Se não existir registro de token associado ao usuário, insere
                userToken = await _unitOfWork.UserTokenRepository.Insert(newUserToken);
            else
            {
                //Se existir registro de token associado ao usuário, atualiza
                await _unitOfWork.UserTokenRepository.Update(newUserToken);
                userToken = result;
            }

            return userToken!;
        }
    }
}
