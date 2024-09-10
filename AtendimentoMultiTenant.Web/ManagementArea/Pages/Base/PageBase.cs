namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Base
{
    public class PageBase : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;

        #endregion

        #region Services

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IStorageService StorageService { get; set; } = null!;

        #endregion

        #region Methods

        /// <summary>
        /// Método que monta o header usado nas requisições autorizadas
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> SetHeaders()
        {

            //TODO: CRIAR O CONCEITO DE TOKEN TEMPORARIA PRA SER USADA PRA GERAR UMA SEGUNDA TOKEN DE ACESSO
            //SENDO QUE A SEGUNDA TOKEN VAI SER SEMPRE CANCELADA APÓS O LOGOUT DO USUÁRIO

            var token = await StorageService.GetItem("token");

            var headers = new Dictionary<string, string> {
                    { "Authorization", $"Bearer {token}" },
                    { "Content-Type", "application/json" }
                };

            return headers;
        }

        #endregion
    }
}
