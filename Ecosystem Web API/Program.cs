using AccessLogic.Repositories;
using AppLogic.UCInterfaces;
using AppLogic.UseCases;
using Domain.RepositoryInterfaces;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ecosystem
builder.Services.AddScoped<IRepositoryEcosystems, EcosystemsRepository>();
builder.Services.AddScoped<IListEcosystem, ListEcosUC>();
builder.Services.AddScoped<IAddEcosystem, AddEcoUC>();

// DB config
ConfigurationBuilder configurationBuilder = new();
configurationBuilder.AddJsonFile("appsettings.json", false, true);
var config = configurationBuilder.Build();
string connectionString = config.GetConnectionString("Connection1");
builder.Services.AddDbContextPool<EcosystemContext>(Options => Options.UseSqlServer(connectionString));

// Params
builder.Services.AddScoped<IRepositoryParams, ParamsRepository>();
builder.Services.AddScoped<IModifyLengthParam, ModifyLengthParamUC>();
DbContextOptionsBuilder<EcosystemContext> b = new();
b.UseSqlServer(connectionString);
var options = b.Options;
EcosystemContext context = new(options);
ParamsRepository repo = new(context);

Name.MinNameLength = int.Parse(repo.FindValue("MinNameLength"));
Name.MaxNameLength = int.Parse(repo.FindValue("MaxNameLength"));
Description.MinDescLength = int.Parse(repo.FindValue("MinDescLength"));
Description.MaxDescLength = int.Parse(repo.FindValue("MaxDescLength"));

// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
