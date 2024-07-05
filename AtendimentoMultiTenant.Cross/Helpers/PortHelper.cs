namespace AtendimentoMultiTenant.Cross.Helpers
{
    /// <summary>
    /// Classe que auxilia na busca por uma nova porta
    /// </summary>
    public class PortHelper
    {
        public static IUnitOfWork? _unitOfWork;

        public PortHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public static string GetPortNumber()
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
