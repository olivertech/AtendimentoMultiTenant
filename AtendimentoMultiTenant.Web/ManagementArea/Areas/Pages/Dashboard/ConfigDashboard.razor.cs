using AtendimentoMultiTenant.Web.ManagementArea.Areas.Pages.Dashboard;

namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Dashboard
{
    public partial class ConfigDashboardPage : PageBase
    {
        #region Properties

        #endregion

        #region Services

        [Inject]
        public IConfigDashboardHandler Handler { get; set; } = null!;

        #endregion

        #region Methods

        //CRIAR AQUI O MÉTODO PRA RECEBER OS ITENS DE MENU... VER NO VIDEO DO BALTA COMO FAZ...

        #endregion
    }
}
