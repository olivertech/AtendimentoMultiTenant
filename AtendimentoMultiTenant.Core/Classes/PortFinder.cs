namespace AtendimentoMultiTenant.Core.Classes
{
    /// <summary>
    /// Classe que auxilia na busca por uma nova porta
    /// </summary>
    public class PortFinder : IPortFinder
    {
        protected readonly IUnitOfWork? _unitOfWork;

        public PortFinder(IUnitOfWork unitOfWork)
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

                if(!_unitOfWork!.PortRepository.GetList(x => x.PortNumber == randomPort).Result!.Any())
                {  ok = true; }

            } while (!ok);

            return randomPort;
        }
    }
}
