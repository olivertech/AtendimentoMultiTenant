var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//==================
// Adding MudBlazor
//==================
builder.Services.AddMudServices();

//======================
// Configuração do Http
//======================
builder.Services.AddHttpClient(SharedConfigurations.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(SharedConfigurations.BackEndUrl);
    opt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

//===============================
// Validations on Shared Project
//===============================
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(LoginRequestValidator).Assembly));

//====================
// Handler Injections
//====================
builder.Services.AddHandlerDependenciesInjection();

//================================
// Adding Session Storage Handler
//================================
builder.Services.AddBlazoredSessionStorage(config =>
    config.JsonSerializerOptions.WriteIndented = true
);

await builder.Build().RunAsync();
