var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//==================
// Adding MudBlazor
//==================
builder.Services.AddMudServices();

//================================
// Adding Session Storage Handler
//================================
builder.Services.AddBlazoredSessionStorage();

//======================
// Configuração do Http
//======================
builder.Services.AddHttpClient(SharedConfigurations.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(SharedConfigurations.BackEndUrl);
});

//===============================
// Validations on Shared Project
//===============================
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(LoginRequestValidator).Assembly));

//====================
// Handler Injections
//====================
builder.Services.AddHandlerDependenciesInjection();

await builder.Build().RunAsync();
