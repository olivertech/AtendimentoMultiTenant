var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

//======================
// Configuração do Http
//======================
builder.Services.AddHttpClient(WebConfigurations.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(CoreConfigurations.BackendUrl);
});

builder.Services.AddTransient<IContainerDbHttpClientHandler, ContainerDbHttpClientHandler>();
builder.Services.AddTransient<ILoginHttpClientHandler, LoginHttpClientHandler>();

await builder.Build().RunAsync();
