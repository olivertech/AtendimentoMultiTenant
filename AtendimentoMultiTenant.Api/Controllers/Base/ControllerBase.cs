namespace AtendimentoMultiTenant.Api.Controllers.Base
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
        /// Método que valida o usuário, recuperando seus dados a partir do email passado no token
        /// e verificando se esse usuário tem o tipo informado igual ao do banco de dados.
        /// Essa é uma segunda checagem de proteção, caso um alguém tente recriar o token manualmente.
        /// TODO: COM O FRONT PRONT, QUE VAI GRAVAR O TOKEN EM COOKIE COM MAIS INFORMAÇÃO, 
        /// MODIFICAR ESSE MÉTODO PRA RECEBER TB O VALOR GERADO NO COOKIE, QUE PODERÁ SER UMA GUID
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        protected bool IsUserClaimsValid(ClaimsIdentity identity)
        {
            if (identity == null)
                return false;

            var claims = identity.Claims;
            var role = claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()!.Value;
            var identifier = claims.Where(x => x.Type == ClaimTypes.Hash).FirstOrDefault()!.Value;

            Dictionary<string, Guid> guids = IdentifierHelper.GetIdentifier(identifier);

            var user = _unitOfWork!.UserRepository.GetById(guids["USERID"]).Result;
            var token = _unitOfWork!.UserTokenRepository.GetById(guids["TOKENID"]).Result;
            var userType = _unitOfWork!.UserTypeRepository.GetById(user!.UserTypeId).Result;
            
            if (user != null && token != null)
            {
                if (userType!.Name!.ToLower() == role.ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
