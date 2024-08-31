namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu.Detail
{
    public partial class RoleDetailPage : PageBase
    {
        #region Properties

        public RoleResponse InputModel { get; set; } = new();
        public List<MenuResponse>? ListMenus { get; set; }
        public List<RoleMenuResponse>? ListRoleMenus { get; set; }

        public Guid MenuId { get; set; }

        #endregion

        #region Services

        [Inject]
        public IRoleDetailHandler Handler { get; set; } = null!;

        [Inject]
        public IMenuHandler MenuHandler { get; set; } = null!;

        [Inject]
        public IRoleMenuHandler RoleMenuHandler { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task LoadMenus()
        {
            ResponseFactory<IEnumerable<MenuResponse>>? resultMenu = null!;
            ResponseFactory<IEnumerable<RoleMenuResponse>>? resultRoleMenu = null!;
            IsBusy = true;

            try
            {
                //var user = 
                resultMenu = await MenuHandler.GetAll();
                //resultRoleMenu = await RoleMenuHandler.GetList(x => x.RoleId == 

                if (resultMenu.IsSuccess)
                {
                    ListMenus = resultMenu.Result!.ToList();
                    //ListRoleMenus =  
                    Snackbar.Add(resultMenu.Message, MudBlazor.Severity.Success);
                }
                else
                    Snackbar.Add(resultMenu.Message, MudBlazor.Severity.Warning);
            }
            catch (Exception)
            {
                Snackbar.Add(resultMenu.Message, MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
                StateHasChanged();
            }
        }

        public async Task GetRole(Guid id)
        {
            IsBusy = true;
            ResponseFactory<RoleResponse> result = null!;

            try
            {
                result = await Handler.GetById(id!);

                if (result.IsSuccess)
                {
                    InputModel = result!.Result!;
                    Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                }
                else
                    Snackbar.Add(result.Message, MudBlazor.Severity.Warning);

            }
            catch (Exception)
            {
                Snackbar.Add(result.Message, MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
                StateHasChanged();
            }
        }

        public void OnInvalidSubmit()
        {
            Snackbar.Add("Preencha o formuário corretamente", MudBlazor.Severity.Warning);
        }

        public async Task OnValidSubmitAsync()
        {
            ResponseFactory<RoleResponse> result = new();
            IsBusy = true;

            try
            {
                var request = Mapper!.Map<RoleRequest>(InputModel);

                if (request.Id == Guid.Empty)
                {
                    result = await Handler.Insert(request);
                }
                else
                {
                    result = await Handler.Update(request);
                }

                if (result != null)
                {
                    if (result.IsSuccess)
                    {
                        Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                        NavigationManager.NavigateTo(RoutesEnumerator.Roles.GetDescription(), false, true);
                    }
                    else
                        Snackbar.Add(result.Message, MudBlazor.Severity.Warning);
                }
                else
                    Snackbar.Add("Não foi possível salvar os dados da role.", MudBlazor.Severity.Error);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void GoBack()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.Roles.GetDescription(), false, true);
        }

        #endregion
    }
}
