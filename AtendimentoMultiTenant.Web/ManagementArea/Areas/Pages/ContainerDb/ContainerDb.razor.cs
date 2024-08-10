﻿namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.ContainerDb
{
    public partial class ContainerDbPage : PageBase
    {
        #region Properties

        public List<ContainerDbResponse>? List = new List<ContainerDbResponse>();

        #endregion

        #region Services

        [Inject]
        public IContainerDbHandler Handler { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetContainers()
        {
            IsBusy = true;
            ResponseFactory<IEnumerable<ContainerDbResponse>>? result = null!;

            try
            {
                result = await Handler.GetAll();

                if (result.IsSuccess)
                {
                    List = result.Result!.ToList();
                    Snackbar.Add(result.Message, Severity.Success);
                }
                else
                    Snackbar.Add(result.Message, Severity.Warning);
            }
            catch (Exception)
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
                StateHasChanged();
            }
        }

        #endregion
    }
}
