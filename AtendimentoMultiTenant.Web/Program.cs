using AtendimentoMultiTenant.Core.Classes;
using AtendimentoMultiTenant.Web.Classes;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddHttpClient(WebConfigurations.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(CoreConfigurations.BackendUrl);
});

await builder.Build().RunAsync();
