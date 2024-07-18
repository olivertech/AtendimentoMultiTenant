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
    }
}
