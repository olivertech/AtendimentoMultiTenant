namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.ContainerDb
{
    public partial class ContainerDbPage : PageBase
    {
        #region Properties

        #endregion

        #region Services

        [Inject]
        public IContainerDbHandler Handler { get; set; } = null!;

        #endregion

        #region Methods

        #endregion
    }
}
