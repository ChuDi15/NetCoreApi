using MySql.Data.MySqlClient;
using NetCoreApiAssesment.Data;
using NetCoreApiAssesment.Data.Repositories;
using MySqlConfiguration = NetCoreApiAssesment.Data.MySqlConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConfiguration = new MySqlConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySQLConfiguration);

//builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MySqlConnection")));

builder.Services.AddScoped<IOwnersRepository, OwnersRepository>();
builder.Services.AddScoped<IVehiclesRepository, VehiclesRepository>();
builder.Services.AddScoped<IClaimsRepository, ClaimsRepository>();


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
