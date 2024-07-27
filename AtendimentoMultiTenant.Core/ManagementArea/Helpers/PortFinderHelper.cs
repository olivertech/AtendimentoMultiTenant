using AtendimentoMultiTenant.Core.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Core.ManagementArea.Helpers
{
    /// <summary>
    /// Classe que auxilia na busca por uma nova porta
    /// </summary>
    public class PortFinderHelper : IPortFinder
    {
        protected readonly IUnitOfWork? _unitOfWork;

        public PortFinderHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetNewPortNumber()
        {
            bool ok = false;
            string randomPort = string.Empty;

            do
            {
                Random rnd = new Random();
                randomPort = rnd.Next(5000, 9000).ToString();

                if (!_unitOfWork!.PortRepository.GetList(x => x.PortNumber == randomPort).Result!.Any())
                { ok = true; }

            } while (!ok);

            return randomPort;
        }
    }
}
