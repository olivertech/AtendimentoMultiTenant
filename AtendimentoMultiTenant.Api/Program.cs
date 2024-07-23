//=============================================================================================
// Inicialização do NLog para permitir seu funcionamento, antes que a aplicação seja levantada
//=============================================================================================
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.ResponseCompression;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    //=====================================================
    // NLog: Configurando o NLog para Dependency injection
    //=====================================================
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    //======================================================================================
    // Informando para aplicação que vai trabalhar com autenticação, autorização usando JWT
    //======================================================================================
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.UseSecurityTokenValidators = true;
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidIssuer = JwtSettings.JwtIssuer,
            ValidAudience = JwtSettings.JwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSettings.SecretKey)),
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.Zero,
        };
        //x.Events = new JwtBearerEvents
        //{
        //    OnChallenge = context =>
        //    {
        //        // Customize challenge behavior (e.g., redirect to login page)
        //        return Task.CompletedTask;
        //    },
        //    OnTokenValidated = context =>
        //    {
        //        //var userservice = context.HttpContext.RequestServices.GetRequiredService<iapiuserservice>();
        //        //var userid = int.Parse(context.Principal.identity.name);
        //        //var user = userservice.getbyid(userid);
        //        //if (user == null)
        //        //{
        //        //    // return unauthorized if user no longer exists
        //        //    context.Fail("unauthorized");
        //        //}

        //        if (context.Principal == null)
        //            context.Fail("Usuário inválido ou inexistente!");

        //        var unitofWork = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();

        //        //var userId = User.(ClaimTypes.NameIdentifier).Value;

        //        //PAREI AQUI... COMO RECUPERAR OS CLAINS DA TOKEN
        //        //unitofWork.UserRepository.GetByEmail(context.Principal.Identity.GetType())
        //        return Task.CompletedTask;
        //    }
        //};
    });

    //=============================
    // Referenciando o appsettings
    //=============================
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .AddEnvironmentVariables()
        .Build();

    //===============================
    // Add services to the container
    //===============================
    builder.Services
        .AddQuartz()
        .AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        })
        .ConfigureOptions<PostgreSqlContainerCreationJobSetup>()
        .AddEndpointsApiExplorer()
        //Cria o botão de autorização no Swagger
        .AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "AtendimentoMultiTenant.Api", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme.",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        })
        .AddAutoMapper(typeof(Program))
        .AddControllersWithViews()
        .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

    //==================================
    // Add to permit to work with razor
    //==================================
    //builder.Services.AddRazorPages(); //For Blazor

    // Register HTTP Client for OneSignal
    builder.Services.AddHttpClient("OneSignal", client =>
    {
        var config = builder.Configuration;
        client.BaseAddress = new Uri("https://onesignal.com/api/v1/");
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {config["OneSignal:ApiKey"]}");
        client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
    });

    //============================
    // Add Injection Dependencies
    //============================
    builder.Services.AddDependenciesInjection(builder.Configuration);

    //==================
    // Add a Quartz Job
    // https://medium.com/@caio_tito/criando-agendamento-de-tarefas-com-quartz-em-c-e3bebb88d778
    //==================
    //builder.Services.ConfigureOptions<PostgreSqlContainerCreationJobSetup>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
        //app.UseWebAssemblyDebugging(); //For Blazor
    }

    app.UseHttpsRedirection();

    //app.UseBlazorFrameworkFiles(); //For Blazor
    //app.UseStaticFiles(); //For Blazor

    app.UseAuthentication();
    app.UseAuthorization();

    //app.MapRazorPages(); //For Blazor
    app.MapControllers();
    app.MapFallbackToFile("index.html"); //For Blazor

    //app.MapGet("/", () => "Hello, World!");
    //app.MapPost("/api/Configuration/Insert", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret").RequireAuthorization();

    app.Run();
}
catch (Exception exception)
{
    //================================================
    // NLog: Captura de erros de configuração do NLog
    //================================================
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    //======================================================================================
    // Gantir que seja feita o flush de memória e parada interna completa de timers/threads
    // antes do termino da aplicação (Avoid segmentation fault on Linux)
    //======================================================================================
    NLog.LogManager.Shutdown();
}
