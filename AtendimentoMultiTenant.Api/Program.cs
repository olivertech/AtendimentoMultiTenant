//=============================================================================================
// Inicialização do NLog para permitir seu funcionamento, antes que a aplicação seja levantada
//=============================================================================================
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSettings.SecretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

    //=============================
    // Referenciando o appsettings
    //=============================
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
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
        .AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "AtendimentoMultiTenant.Api", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
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
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
            });
        })
        .AddAutoMapper(typeof(Program))
        .AddControllers()
        .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

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
