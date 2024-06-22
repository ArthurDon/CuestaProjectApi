using CustaProject.Infra.Data.Contexts;
using CustaProject.Infra.Data.Repositories;
using CustaProject.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddSingleton<IDbContext>(new MsSqlContext(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICuestaRepository, CuestaRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
