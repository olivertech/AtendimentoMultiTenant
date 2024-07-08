using AtendimentoMultiTenant.Cross.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

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
