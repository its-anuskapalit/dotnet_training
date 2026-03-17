using AIAnomaly.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AIAnomaly.Infrastructure.Repositories;
using AIAnomaly.Application.Interfaces;
using AIAnomaly.Application.Services;
using AIAnomaly.Application.Interfaces;
using AIAnomaly.Application.Services;
using AIAnomaly.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IAnomalyService, AnomalyService>();
builder.Services.AddScoped<IAnomalyRepository, AnomalyRepository>();

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