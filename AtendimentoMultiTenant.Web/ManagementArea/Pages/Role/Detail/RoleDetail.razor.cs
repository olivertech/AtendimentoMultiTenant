namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu.Detail
{
    public partial class RoleDetailPage : PageBase
    {
        #region Properties

        public RoleResponse InputModel { get; set; } = new();
        public List<MenuResponse>? ListMenus { get; set; } = new();
        public List<RoleMenuResponse>? ListRoleMenus { get; set; } = new();
        public string[]? filteredMenus { get; set; } = [];
        public IEnumerable<string>? selectedOptions { get; set; }
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

        public async Task LoadMenus(string id)
        {
            ResponseFactory<IEnumerable<MenuResponse>> MenuList = null!;
            ResponseFactory<IEnumerable<RoleMenuResponse>> RoleMenuList = null!;
            
            IsBusy = true;

            try
            {
                MenuList = await MenuHandler.GetAll();
                RoleMenuList = await RoleMenuHandler.GetRoleMenuList(id);

                if (MenuList.IsSuccess)
                {
                    ListMenus = MenuList.Result!.ToList();
                    ListRoleMenus = RoleMenuList.Result!.ToList();

                    if (ListRoleMenus != null && ListRoleMenus.Count > 0)
                    {
                        filteredMenus = ListMenus.Where(menu => ListRoleMenus.Any(roleMenu => roleMenu.MenuId == menu.Id)).Select(menu => menu.Name).ToArray()!;
                        selectedOptions = new HashSet<string>(filteredMenus);
                    }
                }
            }
            catch (Exception)
            {
                Snackbar.Add(MenuList.Message, MudBlazor.Severity.Error);
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


            //PAREI AQUI... FAZER O TRATAMENTO DA LISTA DE MENUS QUE FICARAM SELECIONADOS NA SELECT PRA ATUALIZAR A TABELA ROLEMENU
            //REMOVENDO TODOS E EM SEGUIDA INSERINDO TODOS QUE FORAM SELECIONADO..
            //OU SEJA... SERÁ UM PROCESSO DE SALVE TANTO DO ROLE EM SI, COMO DA LISTA DE MENUS Q ELE PODE ACESSAR...


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
