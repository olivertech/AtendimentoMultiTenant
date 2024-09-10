namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu.Detail
{
    public partial class RoleDetailPage : PageBase
    {
        #region Properties

        [Parameter]
        public string? Id { get; set; } = null!;

        public RoleResponse InputModel { get; set; } = new();
        public List<MenuResponse>? ListMenus { get; set; } = new();
        public List<RoleMenuResponse>? ListRoleMenus { get; set; } = new();
        public string[]? filteredMenus { get; set; } = [];
        public IEnumerable<string>? selectedOptions { get; set; }
        public Guid MenuId { get; set; }

        #endregion

        #region Services

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        [Inject]
        public IMenuClient MenuClient { get; set; } = null!;

        [Inject]
        public IRoleMenuClient RoleMenuClient { get; set; } = null!;

        [Inject]
        public IRoleClient RoleClient { get; set; } = null!;

        #endregion

        #region Methods

        public async Task LoadMenus(string id)
        {
            ResponseFactory<IEnumerable<MenuResponse>> MenuList = null!;
            ResponseFactory<IEnumerable<RoleMenuResponse>> RoleMenuList = null!;

            IsBusy = true;

            try
            {
                MenuList = await MenuClient.GetAll(await SetHeaders());

                if (id != null)
                {
                    RoleMenuList = await RoleMenuClient.GetRoleMenuList(id!, await SetHeaders());

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
                else
                {
                    ListMenus = MenuList.Result!.ToList();
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
                result = await RoleClient.GetById(id, await SetHeaders());

                if (result.IsSuccess)
                    InputModel = result!.Result!;
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
                    result = await RoleClient.Insert(request, await SetHeaders());
                }
                else
                {
                    result = await RoleClient.Update(request, await SetHeaders());
                }

                //Recupero todos os menus associados ao role consultado
                var resultMenus = await RoleMenuClient.GetRoleMenuList(Id!, await SetHeaders());

                if (resultMenus.IsSuccess)
                {
                    //Remove todos os menus associados ao role
                    foreach (var menu in resultMenus.Result!.ToList())
                    {
                        await RoleMenuClient.Delete(menu.Id!, await SetHeaders()!);
                    }
                }

                if (selectedOptions!.Any())
                {
                    //Insere os novos menus selecionados para o role
                    foreach (var menu in selectedOptions!)
                    {
                        var selectedMenu = ListMenus!.Where(x => x.Name!.Equals(menu)).FirstOrDefault();

                        var newMenu = new RoleMenuRequest
                        {
                             MenuId = selectedMenu!.Id,
                             RoleId = Guid.Parse(Id!),
                             IsActive = true,
                        };

                        await RoleMenuClient.Insert(newMenu!, await SetHeaders()!);

                        await Task.Delay(200);
                    }
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
