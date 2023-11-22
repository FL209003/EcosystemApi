using AccessLogic.Repositories;
using AppLogic.UCInterfaces;
using AppLogic.UseCases;
using Domain.RepositoryInterfaces;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var secretKey = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

builder.Services.AddAuthentication(aut =>
{
    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(aut =>
{
    aut.RequireHttpsMetadata = false;
    aut.SaveToken = true;
    aut.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS para permitir solicitudes desde cualquier origen durante el desarrollo.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Users
builder.Services.AddScoped<IRepositoryUsers, UsersRepository>();
builder.Services.AddScoped<IAddUser, AddUserUC>();
builder.Services.AddScoped<IFindUser, FindUserUC>();

// Ecosystems
builder.Services.AddScoped<IRepositoryEcosystems, EcosystemsRepository>();
builder.Services.AddScoped<IAddEcosystem, AddEcoUC>();
builder.Services.AddScoped<IRemoveEcosystem, RemoveEcoUC>();
builder.Services.AddScoped<IListEcosystem, ListEcosUC>();
builder.Services.AddScoped<IFindEcosystem, FindEcoUC>();

// Species
builder.Services.AddScoped<IRepositorySpecies, SpeciesRepository>();
builder.Services.AddScoped<IAddSpecies, AddSpeciesUC>();
builder.Services.AddScoped<IListSpecies, ListSpeciesUC>();
builder.Services.AddScoped<IRemoveSpecies, RemoveSpeciesUC>();
builder.Services.AddScoped<IFindSpecies, FindSpeciesUC>();
builder.Services.AddScoped<IUpdateSpecies, UpdateSpeciesUC>();

// Threats
builder.Services.AddScoped<IRepositoryThreats, ThreatsRepository>();
builder.Services.AddScoped<IAddThreat, AddThreatUC>();
builder.Services.AddScoped<IListThreats, ListThreatsUC>();
builder.Services.AddScoped<IFindThreat, FindThreatUC>();

//Countries
builder.Services.AddScoped<IRepositoryCountries, CountriesRepository>();
builder.Services.AddScoped<IListCountries, ListCountriesUC>();
builder.Services.AddScoped<IFindCountry, FindCountryUC>();

//Conservation
builder.Services.AddScoped<IRepositoryConservations, ConservationsRepository>();
builder.Services.AddScoped<IFindConservation, FindConservationUC>();

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
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
