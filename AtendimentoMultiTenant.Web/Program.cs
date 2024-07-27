var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

//======================
// Configuração do Http
//======================
builder.Services.AddHttpClient(SharedConfigurations.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(SharedConfigurations.BackendUrl);
});

builder.Services.AddTransient<IContainerDbHandler, ContainerDbHandler>();
builder.Services.AddTransient<ILoginHandler, LoginHandler>();

await builder.Build().RunAsync();
