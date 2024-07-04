var builder = WebApplication.CreateBuilder(args);

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
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "AtendimentoMultiTenant.Api", Version = "v1" });
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

app.UseAuthorization();

app.MapControllers();

app.Run();
