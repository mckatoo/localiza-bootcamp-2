using Localiza.Frotas.Domain;
using Localiza.Frotas.Infra.Facade;
using Localiza.Frotas.Infra.Repository.EF;
using Localiza.Frotas.Infra.Singleton;
using Microsoft.EntityFrameworkCore;

IConfiguration configuration = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
  .AddJsonFile("appsettings.Development.json", optional: true)
  .AddEnvironmentVariables()
  .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<SingletonContainer>();
// builder.Services.AddSingleton<IVeiculoRepository, InMemoryRepository>();
// add EF
builder.Services.AddTransient<IVeiculoRepository, FrotaRepositoryEFMemory>();
builder.Services.AddDbContext<FrotaContext>(options => options.UseInMemoryDatabase("Frota"));

builder.Services.AddTransient<IVeiculoDetran, VeiculoDetranFacade>();

// Configuração do Detran
builder.Services.Configure<DetranOptions>(configuration.GetSection("DetranOptions"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
