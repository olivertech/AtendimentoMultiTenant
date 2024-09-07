using AtendimentoMultiTenant.Web.RefitClients;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//================================
// Adding MudBlazor Configuration
//================================
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = true;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});


//======================
// Configuração do Http
//======================
builder.Services.AddHttpClient(SharedConfigurations.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(SharedConfigurations.BackEndUrl);
    opt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

//============
// Automapper
//============
builder.Services.AddAutoMapper(typeof(Program));

//===============================
// Validations on Shared Project
//===============================
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(LoginRequestValidator).Assembly));

//======================================
// Handler And Refit Clients Injections
//======================================
builder.Services.AddHandlerDependenciesInjection();
builder.Services.AddRefitClientsDependenciesInjection();

//================================
// Adding Session Storage Handler
//================================
builder.Services.AddBlazoredSessionStorage(config =>
    config.JsonSerializerOptions.WriteIndented = true
);

await builder.Build().RunAsync();
