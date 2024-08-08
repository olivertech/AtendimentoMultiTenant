namespace AtendimentoMultiTenant.Api.ManagementArea.Controllers.Base
{
    public abstract class ControllerBase : Controller
    {
        protected readonly IUnitOfWork? _unitOfWork;
        protected readonly IMapper? _mapper;
        protected readonly IConfiguration? _configuration;
        protected string? _nomeEntidade;

        public ControllerBase(IUnitOfWork unitOfWork,
                              IMapper? mapper,
                              IConfiguration? configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        /// <summary>
        /// Método que faz uma 2a validação de acesso aos endpoints
        /// As Secrets serão automaticamente atualizadas por meio 
        /// de um robô a cada 24 horas, gerando sequenciais aleatórios
        /// que criaram mais uma camada de segurança no acesso aos
        /// endpoints de gerenciamento
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        protected bool IsUserClaimsValid()
        {
            try
            {
                ClaimsIdentity? _claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

                var claims = _claimsIdentity!.Claims;
                var role = claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()!.Value;
                var email = claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()!.Value;
                var secret = claims.Where(x => x.Type == ClaimTypes.Hash).FirstOrDefault()!.Value;

                var auth = HttpContext.Response.Headers.Authorization;

                var user = _unitOfWork!.UserRepository.GetByEmail(email).Result;
                var tenant = _unitOfWork!.TenantRepository.GetTenantBySecret(secret).Result;

                if (user != null && tenant != null)
                {
                    return true;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
