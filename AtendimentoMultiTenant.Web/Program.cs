var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddHttpClient(WebConfigurations.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(CoreConfigurations.BackendUrl);
});

builder.Services.AddTransient<IContainerDbHttpClientHandler, ContainerDbHttpClientHandler>();

await builder.Build().RunAsync();
