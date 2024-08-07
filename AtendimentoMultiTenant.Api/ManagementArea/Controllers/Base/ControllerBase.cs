using AtendimentoMultiTenant.Api.ManagementArea.Helpers;

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
                var identifier = claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault()!.Value;

                Dictionary<string, Guid> guids = IdentifierHelper.GetIdentifier(identifier);

                var auth = HttpContext.Response.Headers.Authorization;

                //var user = _unitOfWork!.UserRepository.GetById(guids["USERID"]).Result;
                var token = _unitOfWork!.TokenAccessRepository.GetById(guids["TOKENID"]).Result;
                //var userRole = _unitOfWork!.RoleRepository.GetById(user!.RoleId).Result;

                //if (user != null) // && token != null)
                //{
                //if (userRole!.Name!.Equals(role, StringComparison.CurrentCultureIgnoreCase))
                //{
                //    return true;
                //}
                //}

                return true;
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}
