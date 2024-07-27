using AtendimentoMultiTenant.Infra.Context;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace AtendimentoMultiTenant.Api.Extensios
{
    public class BuilderExtension
    {
        //public static void AddConfiguration(this WebApplicationBuilder builder)
        //{
            
        //    Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        //    Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        //}

        //public static void AddDocumentation(this WebApplicationBuilder builder)
        //{
        //    builder.Services.AddEndpointsApiExplorer();
        //    builder.Services.AddSwaggerGen(x =>
        //    {
        //        x.CustomSchemaIds(n => n.FullName);
        //    });
        //}

        //public static void AddDataContexts(this WebApplicationBuilder builder)
        //{
        //    builder
        //    .Services
        //    .AddDbContext<AppDbContext>(
        //            x =>
        //            {
        //                x.UseSqlServer(ApiConfiguration.ConnectionString);
        //            });

        //}

        //public static void AddCrossOrigin(this WebApplicationBuilder builder)
        //{
        //    builder.Services.AddCors(
        //        options => options.AddPolicy(
        //            ApiConfiguration.CorsPolicyName,
        //            policy => policy
        //                .WithOrigins([
        //                    Configuration.BackendUrl,
        //                Configuration.FrontendUrl
        //                ])
        //                .AllowAnyMethod()
        //                .AllowAnyHeader()
        //                .AllowCredentials()
        //        ));
        //}

        //public static void AddServices(this WebApplicationBuilder builder)
        //{
        //    builder
        //        .Services
        //        .AddTransient<ICategoryHandler, CategoryHandler>();

        //    builder
        //        .Services
        //        .AddTransient<ITransactionHandler, TransactionHandler>();
        //}
    }
}
